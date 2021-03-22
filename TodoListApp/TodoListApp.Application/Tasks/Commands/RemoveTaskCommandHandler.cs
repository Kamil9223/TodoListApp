using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Tasks.Commands
{
    public class RemoveTaskCommandHandler : IRequestHandler<RemoveTaskCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.Tasks.Get(request.TaskId);

            await _unitOfWork.Tasks.Remove(task);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
