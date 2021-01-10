using MediatR;
using SecurityPractice.Common.ErrorHandling;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace SecurityPractice.Infrastructure.Logging
{
    public class ExceptionOccurredHandler : INotificationHandler<ExceptionOccurred>
    {
        private readonly ILogger _logger;

        public ExceptionOccurredHandler(ILogger logger)
        {
            _logger = logger;
        }

        public Task Handle(ExceptionOccurred notification, CancellationToken cancellationToken)
        {
            _logger.Error(notification.Exception.Message);

            return Task.CompletedTask;
        }
    }
}
