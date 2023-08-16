using FluentValidation;

namespace Vacation.Application.Features.Vacation.Commands.CreateVacation
{
    public class CreateVacationValidator:AbstractValidator<CreateVacationCommand>
    {
        public CreateVacationValidator() 
        {
            RuleFor(p => p.EmployeeName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);

            RuleFor(p => p.Department)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
        }
    }
}
