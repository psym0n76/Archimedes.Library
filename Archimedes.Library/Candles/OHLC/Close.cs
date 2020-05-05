namespace Fx.Domain.Candles.OHLC
{
    public class Close : Price {
        public Close(decimal bid, decimal ask) : base(bid, ask)
        {
        }   
    }
}