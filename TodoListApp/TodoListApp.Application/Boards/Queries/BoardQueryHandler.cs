using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoListApp.Application.Boards.DTO;
using TodoListApp.Application.Tasks.DTO;
using TodoListApp.Core.DomainAccessAbstraction;

namespace TodoListApp.Application.Boards.Queries
{
    public class BoardQueryHandler : IRequestHandler<BoardQuery, BoardDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BoardQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BoardDto> Handle(BoardQuery request, CancellationToken cancellationToken)
        {
            var boards = await _unitOfWork.Boards.GetAllWithTasks(request.userId);

            var sortedBoards = boards.OrderBy(x => x.CategoryName).ToList();

            var mainPanel = new BoardDto
            {
                Categories = sortedBoards.ToDictionary(x => x.TasksBoardId, x => x.CategoryName),
                Tasks = new List<TaskDto>()
            };

            if (sortedBoards.Any())
            {
                foreach (var dbTask in sortedBoards.First().Tasks)
                {
                    mainPanel.Tasks.Add(_mapper.Map<TaskDto>(dbTask));
                }
            }
            
            return mainPanel;
        }
    }
}
