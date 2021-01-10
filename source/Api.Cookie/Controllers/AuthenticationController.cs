using System.Security.Claims;

namespace Api.Cookie.Controllers
{
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using SecurityPractice.Common.Controllers;
    using SecurityPractice.Domain.Customers.AddCustomer;
    using SecurityPractice.Domain.Customers.IsUsernameAvailable;
    using SecurityPractice.Infrastructure.Security.SignIn;

    [ApiController]
    [Route("[controller]")]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(IMediator mediator)
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
        public async Task<IActionResult> SignInCustomer([FromBody] SignInCustomerRequest request)
        {
            return await HandleNoContent(request);
        }

        [Authorize]
        [HttpGet("DoAuthorizedStuff")]
        public async Task<IActionResult> DoAuthorizedStuff()
        {
            return Ok();
        }
    }
}
