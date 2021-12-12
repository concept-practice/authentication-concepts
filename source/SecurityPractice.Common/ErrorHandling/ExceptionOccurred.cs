namespace SecurityPractice.Common.ErrorHandling
{
    using System;
    using MediatR;

    public class ExceptionOccurred : INotification
    {
        public ExceptionOccurred(Exception exception)
        {
            Exception = exception;
        }

        public Exception Exception { get; }
    }
}
