using MediatR;
using System;
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
        private IUnitOfWork _unitOfWork;

        public UserBoardQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MainPanelDto> Handle(UserBoardQuery request, CancellationToken cancellationToken)
        {
            //TODO: EF Core Query should be refacotred. For now just for test
            var userWithMainPanel = await _unitOfWork.Users.GetUserWithFirstBoard(request.userId);

            var mainPanel = new MainPanelDto
            {
                FirstBoardId = userWithMainPanel.Boards.FirstOrDefault().TasksBoardId,
                CategoryNames = userWithMainPanel.Boards.Select(x => x.CategoryName).ToList(),
                Tasks = new List<MainPanelTasksDto>()
            };

            if (mainPanel.FirstBoardId != default)
            {
                foreach(var dbTask in userWithMainPanel.Boards.First().Tasks)
                {
                    mainPanel.Tasks.Add(new MainPanelTasksDto //TODO: automapper
                    {
                        SingleTaskId = dbTask.SingleTaskId,
                        TaskName = dbTask.TaskName,
                        Priority = dbTask.Priority,
                        PredictedBestBeforeDateExceeded = dbTask.PredictedFinishDate > DateTime.Now //TODO: TimeServie is better option than Datetime.Now
                    });
                }
            }

            return mainPanel;
        }
    }
}
