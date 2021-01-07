using System;
using System.Transactions;

namespace Archimedes.Library.RabbitMq
{
    public class TradeMessageHandlerEventArgs : EventArgs
    {
        public Transaction Transaction { get; set; }
    }
}