using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Tasks.Commands
{
    public class AddTaskDetailCommandHandler : IRequestHandler<AddTaskDetailCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddTaskDetailCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddTaskDetailCommand request, CancellationToken cancellationToken)
        {
            var newTaskDetail = new TaskDetails(request.TaskDetailName, request.TaskDetailDescription);

            var task = await _unitOfWork.Tasks.Get(request.TaskId);
            task.Details.Add(newTaskDetail);
            await _unitOfWork.Complete();

            return Unit.Value;
        }
    }
}
