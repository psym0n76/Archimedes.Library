﻿using System.Collections.Generic;

namespace Archimedes.Library.Message
{
    public class RequestPrice : IRequest
    {
        public string Text { get; set; }
        public IList<string> Properties { get; set; }
        public string Status { get; set; }
    }
}