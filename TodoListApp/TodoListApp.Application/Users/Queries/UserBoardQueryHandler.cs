using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Users.DTO;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Users.Queries
{
    public class UserBoardQueryHandler : IRequestHandler<UserBoardQuery, MainPanelDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserBoardQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MainPanelDto> Handle(UserBoardQuery request, CancellationToken cancellationToken)
        {
            var userWithMainPanel = await _unitOfWork.Users.GetUserWithBoards(request.userId);

            var sortedBoards = userWithMainPanel.Boards.OrderBy(x => x.CategoryName).ToList();

            var mainPanel = new MainPanelDto
            {
                CategoryNames = sortedBoards.Select(x => x.CategoryName).ToList(),
                Tasks = new List<MainPanelTasksDto>()
            };

            if (sortedBoards.Any())
            {
                foreach (var dbTask in sortedBoards.First().Tasks)
                {
                    mainPanel.Tasks.Add(_mapper.Map<MainPanelTasksDto>(dbTask));
                }
            }
            
            return mainPanel;
        }
    }
}
