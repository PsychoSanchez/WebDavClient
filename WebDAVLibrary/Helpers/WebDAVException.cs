using System;
using System.Runtime.Serialization;
using System.Web;
using System.Windows.Forms;

namespace WebDAVLibrary.Helpers
{
    public class WebDAVException : HttpException
    {
        public WebDAVException()
        {
        }

        public WebDAVException(string message)
            : base(message)
        {
            MessageBox.Show(message);
        }

        public WebDAVException(string message, int hr)
            : base(message, hr)
        {
            MessageBox.Show(message);
        }

        public WebDAVException(string message, Exception innerException)
            : base(message, innerException)
        {
            MessageBox.Show(message);
        }

        public WebDAVException(int httpCode, string message, Exception innerException)
            : base(httpCode, message, innerException)
        {
            MessageBox.Show(message);
        }

        public WebDAVException(int httpCode, string message)
            : base(httpCode, message)
        {
            MessageBox.Show(message);
        }

        public WebDAVException(int httpCode, string message, int hr)
            : base(httpCode, message, hr)
        {
            MessageBox.Show(message);
        }

        protected WebDAVException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            MessageBox.Show(info.ToString());
        }

        public override string ToString()
        {
            var s = string.Format("HttpStatusCode: {0}", base.GetHttpCode());
            s += Environment.NewLine + string.Format("ErrorCode: {0}", ErrorCode);
            s += Environment.NewLine + string.Format("Message: {0}", Message);
            s += Environment.NewLine + base.ToString();

            return s;
        }
    }
}
