using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Users.DTO;

namespace TodoListApp.Application.Users.Queries
{
    public class UserBoardQueryHandler : IRequestHandler<UserBoardQuery, MainPanelDto>
    {
        public Task<MainPanelDto> Handle(UserBoardQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
