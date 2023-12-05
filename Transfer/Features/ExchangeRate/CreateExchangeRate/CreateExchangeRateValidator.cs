using FluentValidation;

namespace Transfer.Features.ExchangeRate.CreateExchangeRate;

public class CreateExchangeRateValidator : AbstractValidator<CreateExchangeRateRequest>
{
    public CreateExchangeRateValidator()
    {
        RuleFor(r => r.Currency1Id)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле Currency1Id не должно быть пустым!");

        RuleFor(r => r.Currency2Id)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле Currency2Id не должно быть пустым!");

        RuleFor(r => r.Rate)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле Rate не должно быть пустым!");
    }
}