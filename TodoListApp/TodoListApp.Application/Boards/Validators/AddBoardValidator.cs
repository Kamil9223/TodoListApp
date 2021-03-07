using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TodoListApp.Application.Boards.Commands;

namespace TodoListApp.Application.Boards.Validators
{
    public class AddBoardValidator : AbstractValidator<AddBoardCommand>
    {
        public AddBoardValidator()
        {
            RuleFor(x => x.categoryName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
