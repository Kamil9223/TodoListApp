using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Users.DTO;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Users.Queries
{
    public class ProfileQueryHandler : IRequestHandler<ProfileQuery, ProfileDto>
    {
        private IUnitOfWork _unitOfWork;

        public ProfileQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProfileDto> Handle(ProfileQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.Get(request.userId);

            return new ProfileDto //TODO: use automapper
            {
                UserId = user.UserId,
                Email = user.Email,
                Points = user.Points
            };
        }
    }
}
