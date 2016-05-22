using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections;
using ITHit.WebDAV.Client;
using ITHit.WebDAV.Client.Exceptions;
using WebDavClient.Dialogs;
using System;

namespace WebDavClient
{
    internal class LockCollection : IEnumerable<KeyValuePair<string, string>>
    {
        private Dictionary<string, string> lockDictionary = new Dictionary<string, string>();

        public void Add(string name, string lockToken)
        {
            if (lockDictionary.ContainsKey(name))
                lockDictionary.Remove(name);
            lockDictionary.Add(name, lockToken);
        }

        public void Add(IHierarchyItem item, string lockToken)
        {
            Add(item.Href.AbsolutePath, lockToken);
        }

        public string GetLock(string name)
        {
            if (lockDictionary.ContainsKey(name))
                return lockDictionary[name];
            else if (lockDictionary.ContainsKey(Interface.DecodeUrl(name)))
                return lockDictionary[Interface.DecodeUrl(name)];
            return null;
        }

        public string this[string name]
        {
            get { return this.GetLock(name); }
        }

        public string this[IHierarchyItem item]
        {
            get { return this[item.Href.AbsolutePath]; }
        }

        public void Remove(string name)
        {
            if (lockDictionary.ContainsKey(name))
                lockDictionary.Remove(name);
            else
                lockDictionary.Remove(Interface.DecodeUrl(name));
        }

        public void Remove(IHierarchyItem item)
        {
            Remove(item.Href.AbsolutePath);
        }

        public int Count
        {
            get { return lockDictionary.Count; }
        }

        public bool ContainsKey(string name)
        {
            return this.lockDictionary.ContainsKey(name) ||
                this.lockDictionary.ContainsKey(Interface.DecodeUrl(name));
        }

        #region IEnumerable<> Members

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return new LockEnumerator(lockDictionary);
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new LockEnumerator(lockDictionary);
        }

        #endregion

        public class LockEnumerator : IEnumerator<KeyValuePair<string, string>>
        {
            private Dictionary<string, string>.Enumerator enumerator;

            public LockEnumerator(Dictionary<string, string> lockDictionary)
            {
                this.enumerator = lockDictionary.GetEnumerator();
            }

            #region IEnumerator<string> Members

            public KeyValuePair<string, string> Current
            {
                get { return enumerator.Current; }
            }

            #endregion

            #region IDisposable Members

            public void Dispose()
            { }

            #endregion

            #region IEnumerator Members

            object IEnumerator.Current
            {
                get { return enumerator.Current; }
            }

            public bool MoveNext()
            {
                return enumerator.MoveNext();
            }

            public void Reset()
            {
            }

            #endregion

        }
    }
    internal static class Informator
    {
        public static void ShowError(string errorText)
        {
            ShowError(errorText, null);
        }

        public static void ShowError(string errorText, IWin32Window owner)
        {
            MessageBox.Show(owner, errorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInfo(string infoText)
        {
            ShowInfo(infoText, null);
        }

        public static void ShowInfo(string infoText, IWin32Window owner)
        {
            MessageBox.Show(owner, infoText, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string infoText)
        {
            MessageBox.Show(infoText, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowWarningOKCancel(string infoText)
        {
            return MessageBox.Show(infoText, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowQuestion(string infoText, string caption)
        {
            return MessageBox.Show(infoText, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
    }
    internal static class ItemOperations
    {
        public static object Delete(IHierarchyItem item, string lockToken)
        {
            try
            {
                item.Delete(lockToken);
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static object Delete(IHierarchyItem item, LockCollection locks)
        {
            return Delete(item, locks[item]);
        }

        public static object DeleteFolder(IFolder folder, LockCollection locks)
        {
            List<LockUriTokenPair> lockPairs = GetLockPairs(folder, locks);
            return Delete(folder, lockPairs.ToArray());
        }

        public static object Delete(IHierarchyItem item, LockUriTokenPair[] lockUriTokenPairs)
        {
            try
            {
                item.Delete(lockUriTokenPairs);
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static bool Move(IHierarchyItem item, IFolder target, bool overwrite)
        {
            return Move(item, target, item.DisplayName, overwrite);
        }

        public static bool Move(IHierarchyItem item, IFolder target, bool overwrite, LockCollection locks)
        {
            return Move(item, target, item.DisplayName, overwrite, locks);
        }

        public static bool Move(IHierarchyItem item, IFolder target, string newName, bool overwrite)
        {
            return Move(item, target, newName, overwrite, null);
        }

        public static bool Move(IHierarchyItem item, IFolder target, string newName,
            bool overwrite, LockCollection locks)
        {
            string sourcePath = item.Href.AbsolutePath;
            bool isSourceFolder = item is IFolder;
            List<LockUriTokenPair> lockPairs = GetLockPairs(item, locks);

            try
            {
                item.MoveTo(target, newName, overwrite,
                    (lockPairs != null) ? lockPairs.ToArray() : null);
                ChangeLocks(sourcePath, isSourceFolder, target, newName, locks);
                return true;
            }
            catch (WebDavException ex)
            {
                WebDavHttpException exept = ex as WebDavHttpException;
                if (exept == null || exept.Multistatus.Responses.Length == 0)
                    Informator.ShowError(item.DisplayName + ": " + ex.Message);
                else return false;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void ChangeLocks(string sourcePath, bool isSourceFolder,
            IFolder target, string newName, LockCollection locks)
        {
            string targetPath = target.Href.AbsolutePath.TrimEnd('/') + '/' + newName;
            if (isSourceFolder)
            {
                List<string> toChange = new List<string>();
                foreach (KeyValuePair<string, string> pair in locks)
                    if (pair.Key.StartsWith(sourcePath))
                        toChange.Add(pair.Key);
                foreach (string path in toChange)
                {
                    string token = locks[path];
                    locks.Remove(path);
                    string newPath = path.Remove(0, sourcePath.Length);
                    newPath = targetPath + '/' + newPath;
                    locks.Add(newPath, token);
                }
            }
            else
            {
                string token = locks[sourcePath];
                locks.Remove(sourcePath);
                locks.Add(targetPath, token);
            }
        }

        private static List<LockUriTokenPair> GetLockPairs(IHierarchyItem item, LockCollection locks)
        {
            List<LockUriTokenPair> lockPairs = new List<LockUriTokenPair>();
            if (locks != null)
            {
                lockPairs = new List<LockUriTokenPair>();
                foreach (KeyValuePair<string, string> pair in locks)
                    if (!string.IsNullOrEmpty(pair.Value))
                        if (pair.Key.StartsWith(item.Href.AbsolutePath))
                            lockPairs.Add(
                                new LockUriTokenPair(
                                    new Uri(item.Href.OriginalString +
                                            pair.Key.Remove(0, item.Href.AbsolutePath.Length)),
                                    pair.Value));
            }
            return lockPairs;
        }

        public static bool Copy(IHierarchyItem item, IFolder target, bool overwrite)
        {
            try
            {
                item.CopyTo(target, item.DisplayName, true, overwrite);
                return true;
            }
            catch (Exception ex)
            {
                Informator.ShowError(item.DisplayName + ": " + ex.Message);
                return false;
            }
        }

        public static IHierarchyItem GetItem(IFolder folder, string name)
        {
            try
            {
                return folder.GetItem(name);
            }
            catch (WebDavException)
            {
                return GetFolder(folder, name);
            }
        }

        public static IFolder GetFolder(IFolder folder, string name)
        {
            try
            {
                return folder.GetFolder(name);
            }
            catch (Exception ex)
            {
                Informator.ShowError(name + ": " + ex.Message);
                return null;
            }
        }

        public static IHierarchyItem[] GetChildren(IFolder folder)
        {
            try
            {
                return folder.GetChildren(false);
            }
            catch (Exception ex)
            {
                Exception e = ex.InnerException ?? ex;
                Informator.ShowError(folder.DisplayName + ": " + e.Message);
                return new IHierarchyItem[0];
            }
        }

        public static IHierarchyItem[] GetChildrenDeep(IFolder folder)
        {
            try
            {
                return folder.GetChildren(true);
            }
            catch (ForbiddenException)
            {
                return null;
            }
            catch (Exception ex)
            {
                Informator.ShowError(folder.DisplayName + ": " + ex.Message);
                return new IHierarchyItem[0];
            }
        }

        public static object PutUnderVersionControl(IResource resource, bool enable, LockCollection locks)
        {
            try
            {
                resource.PutUnderVersionControl(enable, locks[resource]);
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public static object Lock(IHierarchyItem item, LockScope scope, string owner)
        {
            try
            {
                return item.Lock(scope, false, owner, TimeSpan.MaxValue);
            }
            catch (Exception e)
            {
                return e.InnerException ?? e;
            }
        }

        public static object Unlock(IHierarchyItem item, string lockToken)
        {
            try
            {
                item.Unlock(lockToken);
                return null;
            }
            catch (Exception e)
            {
                return e.InnerException ?? e;
            }
        }

        public static object Checkin(IResource item, string lockToken)
        {
            try
            {
                if (lockToken != null)
                    return item.CheckIn(lockToken);
                else
                    return item.CheckIn();
            }
            catch (Exception e)
            {
                return e.InnerException ?? e;
            }
        }

        public static object Checkout(IResource item, string lockToken)
        {
            try
            {
                if (lockToken != null)
                    item.CheckOut(lockToken);
                else
                    item.CheckOut();
                return null;
            }
            catch (Exception e)
            {
                return e.InnerException ?? e;
            }
        }

        public static object UnCheckOut(IResource item, string lockToken)
        {
            try
            {
                if (lockToken != null)
                    item.UnCheckOut(lockToken);
                else
                    item.UnCheckOut();
                return null;
            }
            catch (Exception e)
            {
                return e.InnerException ?? e;
            }
        }

        public static bool UpdateToVersion(IResource item, IVersion version, string lockToken)
        {
            try
            {
                if (lockToken != null)
                    item.UpdateToVersion(version, lockToken);
                else
                    item.UpdateToVersion(version);
                return true;
            }
            catch (Exception e)
            {
                WebDavHttpException ex = e as WebDavHttpException;
                string status = (ex != null && ex.Status != null)
                                    ? "\nStatus: " + ex.Status.Description
                                    : string.Empty;
                Informator.ShowError(item.DisplayName + ": " + e.Message + status);
                return false;
            }
        }

        public static object SetAutoVersionMode(IResource resource, AutoVersion autoVersionMode, LockCollection locks)
        {
            try
            {
                resource.SetAutoVersion(autoVersionMode, locks[resource]);
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public static object GetAutoVersion(IResource res)
        {
            try
            {
                return res.GetAutoVersion();
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public static void UpdateProperties(IHierarchyItem item, Property[] toAddOrUpdate, PropertyName[] toDelete, string lockToken)
        {
            try
            {
                item.UpdateProperties(toAddOrUpdate, toDelete, lockToken);
            }
            catch (Exception e)
            {
                Informator.ShowError(e.ToString());
            }
        }
    }
}
