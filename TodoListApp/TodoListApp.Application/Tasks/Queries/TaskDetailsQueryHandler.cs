using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Tasks.ViewModels;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Tasks.Queries
{
    public class TaskDetailsQueryHandler : IRequestHandler<TaskDetailsQuery, TaskInfoWithDetailsViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TaskInfoWithDetailsViewModel> Handle(TaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var taskWithDetails = await _unitOfWork.Tasks.GetWithDetails(request.TaskId);

            return _mapper.Map<TaskInfoWithDetailsViewModel>(taskWithDetails);
        }
    }
}
