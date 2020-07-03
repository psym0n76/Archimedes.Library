using System.Collections.Generic;

namespace Archimedes.Library.Message
{
    public interface IResponse<T> where T : class
    {
        string Text { get; set; }
        string Status { get; set; }
        IEnumerable<T> Payload { get; set; }
    }
}