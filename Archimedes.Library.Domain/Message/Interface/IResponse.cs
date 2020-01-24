namespace Archimedes.Library.Message
{
    public interface IResponse
    {
        string Text { get; set; }
        string Status { get; set; }
    }
}