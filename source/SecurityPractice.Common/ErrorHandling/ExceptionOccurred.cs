using MediatR;

namespace SecurityPractice.Common.ErrorHandling
{
    using System;

    public class ExceptionOccurred : INotification
    {
        public ExceptionOccurred(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; }
    }
}
