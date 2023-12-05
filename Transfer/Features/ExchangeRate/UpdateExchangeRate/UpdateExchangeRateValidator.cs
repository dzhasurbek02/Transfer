using FluentValidation;

namespace Transfer.Features.ExchangeRate.UpdateExchangeRate;

public class UpdateExchangeRateValidator : AbstractValidator<UpdateExchangeRateRequest>
{
    public UpdateExchangeRateValidator()
    {
        RuleFor(r => r.Id)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле Id не должно быть пустым!");
        
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