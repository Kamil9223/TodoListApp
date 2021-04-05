using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Users.ViewModels;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Users.Queries
{
    public class ProfileQueryHandler : IRequestHandler<ProfileQuery, ProfileViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProfileQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProfileViewModel> Handle(ProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.Get(request.userId);

            return _mapper.Map<ProfileViewModel>(user);
        }
    }
}
