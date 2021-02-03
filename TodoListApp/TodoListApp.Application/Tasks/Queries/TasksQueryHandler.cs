using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Tasks.DTO;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Tasks.Queries
{
    public class TasksQueryHandler : IRequestHandler<TasksQuery, TasksCollectionDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TasksQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TasksCollectionDto> Handle(TasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _unitOfWork.Tasks.GetTasksFromBoard(request.TasksBoardId);

            return _mapper.Map<TasksCollectionDto>(tasks);
        }
    }
}
