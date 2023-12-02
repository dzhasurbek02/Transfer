using FluentValidation;

namespace Transfer.Features.Account.CreateAccount;

public class CreateAccountValidator : AbstractValidator<CreateAccountRequest>
{
    public CreateAccountValidator()
    {
        RuleFor(a => a.UserId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле UserId не должно быть пустым!");

        RuleFor(a => a.CurrencyId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле CurrencyId не должно быть пустым!");

        RuleFor(a => a.Balance)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле Balance не должно быть пустым!");
    }
}