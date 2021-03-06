using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Boards.Commands
{
    public class AddBoardCommandHandler : IRequestHandler<AddBoardCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddBoardCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddBoardCommand request, CancellationToken cancellationToken)
        {
            var newBoard = new TasksBoard(request.categoryName);

            var user = await _unitOfWork.Users.Get(request.userId);
            user.Boards.Add(newBoard);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
