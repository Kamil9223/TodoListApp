using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Tasks.DTO;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Tasks.Queries
{
    public class TasksQueryHandler : IRequestHandler<TasksQuery, List<MainPanelTasksDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TasksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MainPanelTasksDto>> Handle(TasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _unitOfWork.Tasks.GetTasksFromBoard(request.TasksBoardId);
            var result = new List<MainPanelTasksDto>();

            foreach(var task in tasks)
            {
                result.Add(_mapper.Map<MainPanelTasksDto>(task));
            }

            return result;
        }
    }
}
