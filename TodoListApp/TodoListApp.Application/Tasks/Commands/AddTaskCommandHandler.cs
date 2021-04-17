using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Common;
using TodoListApp.Core.Domain;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Tasks.Commands
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, ErrorResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorResponse> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var createdAt = DateTime.Now;

            var newTask = new SingleTask(
                request.TaskName,
                createdAt,
                request.PredictedFinishDate,
                request.Priority);

            var board = await _unitOfWork.Boards.Get(request.BoardId);
            board.Tasks.Add(newTask);
            await _unitOfWork.Complete();

            return request.ErrorModel;
        }
    }
}
