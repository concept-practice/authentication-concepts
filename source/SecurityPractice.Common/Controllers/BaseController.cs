namespace SecurityPractice.Common.Controllers
{
    using System;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using SecurityPractice.Common.ErrorHandling;
    using SecurityPractice.Common.Validation;

    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> HandleOk<TResponse>(IRequest<TResponse> request)
        {
            return await Execute(request, response => Ok(response));
        }

        protected async Task<IActionResult> HandleCreated<TResponse>(IRequest<TResponse> request, Func<TResponse, Uri> uriFunc)
        {
            return await Execute(request, response => Created(uriFunc.Invoke(response), response));
        }

        protected async Task<IActionResult> HandleNoContent<TResponse>(IRequest<TResponse> request)
        {
            return await Execute(request, response => NoContent());
        }

        private async Task<IActionResult> Execute<TResponse>(IRequest<TResponse> request, Func<TResponse, IActionResult> responseFunc)
        {
            IActionResult response;

            var validationResult = ObjectVerification.Validate(request);
            if (validationResult.Failed)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                var result = await _mediator.Send(request);

                response = responseFunc.Invoke(result);
            }
            catch (Exception exception)
            {
                await _mediator.Publish(new ExceptionOccurred(exception));

                return BadRequest(exception.Message);
            }

            return response;
        }
    }
}
