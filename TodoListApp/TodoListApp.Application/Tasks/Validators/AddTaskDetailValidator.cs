using FluentValidation;
using TodoListApp.Application.Tasks.Commands;

namespace TodoListApp.Application.Tasks.Validators
{
    public class AddTaskDetailValidator : AbstractValidator<AddTaskDetailCommand>
    {
        public AddTaskDetailValidator()
        {
            RuleFor(x => x.TaskDetailName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.TaskDetailDescription)
                .NotEmpty()
                .MaximumLength(1000);
        }
    }
}
