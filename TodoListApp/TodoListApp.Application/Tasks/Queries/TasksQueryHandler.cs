using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Tasks.DTO;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Tasks.Queries
{
    public class TasksQueryHandler : IRequestHandler<TasksQuery, List<TaskDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TasksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<TaskDto>> Handle(TasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _unitOfWork.Tasks.GetAll(request.TasksBoardId);
            var result = new List<TaskDto>();

            foreach(var task in tasks)
            {
                result.Add(_mapper.Map<TaskDto>(task));
            }

            return result;
        }
    }
}
