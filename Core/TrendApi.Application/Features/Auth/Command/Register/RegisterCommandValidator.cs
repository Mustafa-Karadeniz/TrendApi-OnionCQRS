using FluentValidation;

namespace TrendApi.Application.Features.Auth.Command.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50)
            .WithName("İsim Soyisim:");

        RuleFor(x => x.Email)
            .NotEmpty()
            .MaximumLength(60)
            .EmailAddress()
            .MinimumLength(8)
            .WithName("Email adresi:");

        RuleFor(x => x.Password)
            .MinimumLength(6)
            .NotEmpty()
            .WithName("Şifre:");

        RuleFor(x=>x.ConfirmedPassword)
            .MinimumLength(6)
            .NotEmpty()
            .Equal(x=>x.Password)
            .WithName("Şifre Tekrarı:");


    }
}
