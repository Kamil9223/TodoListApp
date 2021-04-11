using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Tasks.Commands
{
    public class RemoveTaskDetailCommandHandler : IRequestHandler<RemoveTaskDetailCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveTaskDetailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveTaskDetailCommand request, CancellationToken cancellationToken)
        {
            var taskDetail = await _unitOfWork.TaskDetails.Get(request.TaskDetailId);

            await _unitOfWork.TaskDetails.Remove(taskDetail);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
