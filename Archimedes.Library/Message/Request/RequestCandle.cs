using System;
using System.Collections.Generic;

namespace Archimedes.Library.Message
{
    public class RequestCandle : IRequest
    {
        public string Text { get; set; }
        public IList<string> Properties { get; set; }
        public string Market { get; set; }
        public string Granularity { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime DateFrom { get; set; }
        public string Status { get; set; }
    }
}