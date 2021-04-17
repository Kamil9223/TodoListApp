using MediatR;
using TodoListApp.Application.Common;

namespace TodoListApp.Application.Boards.Commands
{
    public class RemoveBoardCommand : BaseCommand, IRequest<ErrorResponse>
    {
        public int BoardId { get; set; }
    }
}
