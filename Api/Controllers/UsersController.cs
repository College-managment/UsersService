using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UsersService.Api.Contracts.Users;

namespace UsersService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request, [FromServices] IValidator<CreateUserRequest> validator, CancellationToken ct)
        {
            var correlationId = HttpContext.TraceIdentifier;
            _logger.LogDebug("Starting user creation. CorrelationId={CorrelationId}", correlationId);

            var validationResult = await validator.ValidateAsync(request, ct);
            if (!validationResult.IsValid)
            {
                var hasPolicyViolation = validationResult.Errors.Any(e => e.ErrorMessage == "PasswordPolicyViolation");
                var statusCode = hasPolicyViolation ? StatusCodes.Status422UnprocessableEntity : StatusCodes.Status400BadRequest;
                return StatusCode(statusCode, new ValidationProblemDetails(
                    validationResult.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray())));
            }

            return Ok();
        }
    }
}