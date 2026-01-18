using FluentValidation;
using UsersService.Api.Contracts.Users;

namespace UsersService.Api.Validations
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(x => x.Password)
                .Must(MeetsPasswordPolicy)
                .WithErrorCode("PasswordPolicyViolation")
                .WithMessage("Password does not meet complexity policy");
        }

        private static bool MeetsPasswordPolicy(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            return  password.Any(char.IsUpper) &&
                    password.Any(char.IsLower) &&
                    password.Any(char.IsDigit) &&
                    password.Any(ch => !char.IsLetterOrDigit(ch));
        }
    }
}