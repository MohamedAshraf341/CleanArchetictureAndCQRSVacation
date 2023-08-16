using FluentValidation;
namespace Vacation.Application.Features.Vacation.Commands.UpdateVacation
{
    public class UpdateVacationValidator : AbstractValidator<UpdateVacationCommand>
    {
        public UpdateVacationValidator()
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
