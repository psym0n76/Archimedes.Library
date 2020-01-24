using System.Collections.Generic;

namespace Archimedes.Library.Message
{
    public class RequestTrade:IRequest
    {
        public string Text { get; set; }
        public IList<string> Properties { get; set; }
        public string Status { get; set; }
    }
}