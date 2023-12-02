using FluentValidation;

namespace Transfer.Features.Currency.CreateCurrency;

public class CreateCurrencyValidator : AbstractValidator<CreateCurrencyRequest>
{
    public CreateCurrencyValidator()
    {
        RuleFor(c => c.Type)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле Type не должно быть пустым!")
            .Length(3, 30)
            .WithMessage("Длина Type не должна быть меньше 3 символов и больше 30 символов!");;
    }
}