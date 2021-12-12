namespace SecurityPractice.Bearer.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SecurityPractice.Common.Controllers;
    using Domain.Customers.AddCustomer;
    using Domain.Customers.IsUsernameAvailable;
    using Infrastructure.Security.SignIn;
    using Infrastructure.Security.SignOut;

    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public class BearerAuthenticationController : BaseController
    {
        public BearerAuthenticationController(IMediator mediator)
            : base(mediator)
        {
        }

        [AllowAnonymous]
        [HttpPost("AddCustomer", Name = "AddCustomer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] AddCustomerRequest request)
        {
            return await HandleNoContent(request);
        }

        [AllowAnonymous]
        [HttpGet("IsUsernameAvailable/{username}", Name = "IsUsernameAvailable")]
        [ProducesResponseType(typeof(IsUsernameAvailableResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> IsUsernameAvailable(string username)
        {
            return await HandleOk(new IsUsernameAvailableRequest(username));
        }

        [AllowAnonymous]
        [HttpPost("SignInCustomer", Name = "SignInCustomer")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> SignInCustomer([FromBody] SignInCustomerRequest request)
        {
            var result = await Mediator.Send(request);

            return Ok(result);
        }

        [HttpPost("SignOutCustomer", Name = "SignOutCustomer")]
        public async Task<IActionResult> SignOutCustomer()
        {
            return await HandleNoContent(new SignOutCustomerRequest());
        }

        [Authorize]
        [HttpGet("DoAuthStuff", Name = "DoAuthStuff")]
        public ActionResult<IEnumerable<string>> GetAuthenticated()
        {
            return new string[] { "value1", "value2", "moreshit" };
        }
    }
}