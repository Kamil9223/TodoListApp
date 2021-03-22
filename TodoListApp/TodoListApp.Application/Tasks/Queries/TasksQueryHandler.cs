using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Tasks.DTO;
using TodoListApp.Application.Tasks.ViewModels;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Tasks.Queries
{
    public class TasksQueryHandler : IRequestHandler<TasksQuery, TasksViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TasksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TasksViewModel> Handle(TasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _unitOfWork.Tasks.GetAll(request.TasksBoardId);
            var result = new List<TaskDto>();

            foreach(var task in tasks)
            {
                result.Add(_mapper.Map<TaskDto>(task));
            }

            return new TasksViewModel
            {
                BoardId = request.TasksBoardId,
                Tasks = result
            };
        }
    }
}
