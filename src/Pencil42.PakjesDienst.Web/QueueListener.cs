using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Amqp;
using Amqp.Serialization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pencil42.PakjesDienst.Db;
using Pencil42.PakjesDienst.Db.Amqp;

namespace Pencil42.PakjesDienst.Web
{
    public class QueueListener
        : BackgroundService
    {
        private readonly ILogger<QueueListener> _logger;
        private readonly IHubContext<PakjesHub> _hubcontext;
        private readonly PakjesQueueSettings _settings;

        private Connection _connection;
        private Session _session;
        private ReceiverLink _receiverLink;

        public static QueueListener Instance { get; private set; }

        public QueueListener(IOptions<PakjesQueueSettings> settings,
                            ILogger<QueueListener> logger,
                            IHubContext<PakjesHub> hubcontext)
        {
            _settings = settings.Value;
            _logger = logger;
            _hubcontext = hubcontext;

            Instance = this;

            
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"QueueListener is starting.");

            Address address = new Address(_settings.Address);
            _connection = await Connection.Factory.CreateAsync(address);
            _session = new Session(_connection);


            _receiverLink = new ReceiverLink(_session, "receiver-link", _settings.QueueName);
            _receiverLink.Start(1, OnMessage);

            _logger.LogDebug($"QueueListener started");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // do nothing
        }

        private void OnMessage(IReceiverLink receiverLink, Message message)
        {
            _logger.LogDebug($"QueueListener Message received");

            var pakjeMessage = message.GetBody<PakjeMessage>();
           _receiverLink.Accept(message);

            Task.Run(() => _hubcontext.Clients.All.SendAsync("broadcastMessage", "queue", pakjeMessage));
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"QueueListener stopping.");

            await _receiverLink.CloseAsync();
            await _session.CloseAsync();
            await _connection.CloseAsync();

            _logger.LogDebug($"QueueListener stopped.");

        }
    }
}
