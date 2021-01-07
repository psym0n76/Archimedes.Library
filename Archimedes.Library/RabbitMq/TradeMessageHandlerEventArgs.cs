using System;
using System.Transactions;

namespace Archimedes.Library.RabbitMq
{
    public class TradeMessageHandlerEventArgs : EventArgs
    {
        public TradeTransaction Transaction { get; set; }
    }
}