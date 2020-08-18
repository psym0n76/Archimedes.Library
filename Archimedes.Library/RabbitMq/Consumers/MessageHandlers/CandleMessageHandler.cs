using System;

namespace Archimedes.Library.RabbitMq
{
    public delegate void CandleMessageHandler(object sender, MessageHandlerEventArgs args);

}