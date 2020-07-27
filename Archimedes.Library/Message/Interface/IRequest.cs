﻿using System.Collections.Generic;

namespace Archimedes.Library.Message
{
    public interface IRequest
    {
        string Text { get; set; }
        List<string> Properties { get; set; }
        string Status { get; set; }
    }
}