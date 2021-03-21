using FluentValidation;
using System;
using TodoListApp.Application.Tasks.Commands;

namespace TodoListApp.Application.Tasks.Validators
{
    public class AddTaskValidator : AbstractValidator<AddTaskCommand>
    {
        public AddTaskValidator()
        {
            RuleFor(x => x.TaskName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.PredictedFinishDate)
                .NotEmpty()
                .Must(BeAValidDate)
                .WithMessage("date must be in format: yyyy-mm-dd hh:mm:ss");

            RuleFor(x => x.Priority)
                .NotNull();
        }

        private bool BeAValidDate(DateTime datetime)
        {
            return !(datetime.Year == default ||
                datetime.Month == default ||
                datetime.Day == default ||
                datetime.Hour == default ||
                datetime.Minute == default);
        }
    }
}
