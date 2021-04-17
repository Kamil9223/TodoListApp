using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Common;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Boards.Commands
{
    public class AddBoardCommandHandler : IRequestHandler<AddBoardCommand, ErrorResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddBoardCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorResponse> Handle(AddBoardCommand request, CancellationToken cancellationToken)
        {
            var newBoard = new TasksBoard(request.categoryName);

            var user = await _unitOfWork.Users.Get(request.userId);
            user.Boards.Add(newBoard);
            await _unitOfWork.Complete();

            return request.ErrorModel;
        }
    }
}
