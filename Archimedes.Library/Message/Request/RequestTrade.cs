using System.Collections.Generic;

namespace Archimedes.Library.Message
{
    public class RequestTrade:IRequest
    {
        public string Text { get; set; }
        public List<string> Properties { get; set; }
        public string Status { get; set; }
        public string Account { get; set; }
        public int Lots { get; set; }
        public string  Market { get; set; }

        public string BuySell { get; set; }
    }
}