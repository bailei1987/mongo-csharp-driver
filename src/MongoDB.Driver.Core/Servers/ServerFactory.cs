﻿/* Copyright 2013-2014 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System.Net;
using MongoDB.Driver.Core.ConnectionPools;
using MongoDB.Driver.Core.Events;
using MongoDB.Driver.Core.Misc;

namespace MongoDB.Driver.Core.Servers
{
    /// <summary>
    /// Represents the default server factory.
    /// </summary>
    public class ServerFactory : IServerFactory
    {
        // fields
        private readonly IConnectionPoolFactory _connectionPoolFactory;
        private readonly IServerListener _listener;
        private readonly ServerSettings _settings;

        // constructors
        public ServerFactory(ServerSettings settings, IConnectionPoolFactory connectionPoolFactory, IServerListener listener)
        {
            _settings = Ensure.IsNotNull(settings, "settings");
            _connectionPoolFactory = Ensure.IsNotNull(connectionPoolFactory, "connectionPoolFactory");
            _listener = listener;
        }

        // methods
        public IRootServer Create(DnsEndPoint endPoint)
        {
            return new Server(endPoint, _settings, _connectionPoolFactory, _listener);
        }
    }
}
