using System;
using System.Collections.Generic;

namespace Archimedes.Library.Message
{
    public class CandleRequest : IRequest
    {
        public string Text { get; set; }
        public IList<string> Properties { get; set; }
        public string Market { get; set; }
        public string Granularity { get; set; }
        public string DateTo { get; set; }
        public string DateFrom { get; set; }
        public string Status { get; set; }
    }
}