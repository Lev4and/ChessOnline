using System.Net;

namespace ChessOnline.Model.Common
{
    public class Status
    {
        public string Name { get; }

        public string Message { get; }

        public HttpStatusCode Code { get; }

        public Status(HttpStatusCode code, StatusName name, string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            Code = code;
            Name = name.ToString();
            Message = message;
        }
    }
}