using System.Collections.Generic;

namespace Archimedes.Library.Message
{
    public class RequestPrice : IRequest
    {
        public string Text { get; set; }
        public IList<string> Properties { get; set; }
        public string Status { get; set; }
        public string Market { get; set; }

        public override string ToString()
        {
            return $"\n Price Request: " +
                   $"\n  {nameof(Market)}: {Market} " +
                   $"\n  {nameof(Status)}: {Status} " +
                   $"\n  {nameof(Text)}: {Text}";
        }
    }
}