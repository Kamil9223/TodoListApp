using MediatR;
using TodoListApp.Application.Common;

namespace TodoListApp.Application.Boards.Commands
{
    public class AddBoardCommand : BaseCommand, IRequest<ErrorResponse>
    {
        public int userId { get; set; }
        public string categoryName { get; set; }
    }
}
