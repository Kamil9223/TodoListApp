using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Boards.Commands
{
    public class RemoveBoardCommandHandler : IRequestHandler<RemoveBoardCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveBoardCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveBoardCommand request, CancellationToken cancellationToken)
        {
            var board = await _unitOfWork.Boards.Get(request.BoardId);

            await _unitOfWork.Boards.Remove(board);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
