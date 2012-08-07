﻿using System.Collections.Generic;

namespace Chinchilla.Api
{
    public interface IRabbitAdmin
    {
        IEnumerable<VirtualHost> VirtualHosts { get; }

        IEnumerable<Connection> Connections();

        IEnumerable<Exchange> Exchanges(VirtualHost virtualHost);

        IEnumerable<Queue> Queues(VirtualHost virtualHost);

        bool Create(VirtualHost virtualHost);

        bool Delete(VirtualHost virtualHost);

        bool Delete(Connection connection);

        bool Create(VirtualHost virtualHost, User user, Permissions permissions);

        bool Exists(VirtualHost virtualHost, Queue queue);

        bool Exists(VirtualHost virtualHost, Exchange exchange);
    }
}