namespace Fx.Domain.Candles.Calculations
{
    public class Fibinacci
    {
        private readonly decimal _range;
        private const decimal Fib382 = 0.382m;
        private const decimal Fib50 = 0.5m;
        private const decimal Fib612 = 0.612m;

        public Fibinacci(decimal high, decimal low)
        {
            _range = (high - low);
        }

        public decimal CalcFib382()
        {
            return (_range * Fib382);
        }

        public decimal CalcFib50()
        {
            return (_range * Fib50);
        }

        public decimal CalcFib612()
        {
            return (_range * Fib612);
        }
    }
}