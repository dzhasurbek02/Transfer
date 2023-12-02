using FluentValidation;
using Transfer.Features.Transaction.Requests;

namespace Transfer.Features.Transaction.CreateTransaction;

public class CreateTransactionValidator : AbstractValidator<CreateTransactionRequest>
{
    public CreateTransactionValidator()
    {
        RuleFor(t => t.SenderId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле SenderId не должно быть пустым!");

        RuleFor(t => t.RecipientId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле RecipientId не должно быть пустым!");

        RuleFor(t => t.Sum)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле Sum не должно быть пустым!");
    }
}