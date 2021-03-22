using MediatR;

namespace TodoListApp.Application.Boards.Commands
{
    public class AddBoardCommand : IRequest
    {
        public int userId { get; set; }
        public string categoryName { get; set; }
    }
}
