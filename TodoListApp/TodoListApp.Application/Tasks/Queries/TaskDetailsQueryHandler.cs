using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Tasks.DTO;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Tasks.Queries
{
    public class TaskDetailsQueryHandler : IRequestHandler<TaskDetailsQuery, TaskInfoWithDetailsDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TaskInfoWithDetailsDto> Handle(TaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var taskWithDetails = await _unitOfWork.Tasks.GetWithDetails(request.TaskId);

            return _mapper.Map<TaskInfoWithDetailsDto>(taskWithDetails);
        }
    }
}
