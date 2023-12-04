using FluentValidation;

namespace Transfer.Features.User.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
    {
        RuleFor(u => u.LastName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле LastName не должно быть пустым!")
            .Length(2, 50)
            .WithMessage("Длина LastName не должна быть меньше 2 символов и больше 50 символов!");

        RuleFor(u => u.FirstName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле FirstName не должно быть пустым!")
            .Length(2, 50)
            .WithMessage("Длина FirstName не должна быть меньше 2 символов и больше 50 символов!");

        RuleFor(u => u.PhoneNumber)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле PhoneNumber не должно быть пустым!")
            .Length(11, 20)
            .WithMessage("Длина PhoneNumber не должна быть меньше 11 чисел и больше 20 чисел!");

        RuleFor(u => u.Email)
            .Cascade(CascadeMode.Stop)
            .EmailAddress()
            .WithMessage("Введите правильный EMail")
            .NotEmpty()
            .WithMessage("Поле Email не должно быть пустым!");

        RuleFor(u => u.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .WithMessage("Поле Password не должно быть пустым!");
    }
}