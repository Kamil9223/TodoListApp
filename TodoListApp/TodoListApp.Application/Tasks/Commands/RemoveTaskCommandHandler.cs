using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Common;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Tasks.Commands
{
    public class RemoveTaskCommandHandler : IRequestHandler<RemoveTaskCommand, ErrorResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorResponse> Handle(RemoveTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.Tasks.Get(request.TaskId);

            await _unitOfWork.Tasks.Remove(task);
            await _unitOfWork.Complete();

            return request.ErrorModel;
        }
    }
}
