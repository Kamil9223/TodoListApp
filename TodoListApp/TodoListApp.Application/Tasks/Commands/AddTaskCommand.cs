using MediatR;
using System;
using TodoListApp.Application.Common;
using TodoListApp.Core.Domain;

namespace TodoListApp.Application.Tasks.Commands
{
    public class AddTaskCommand : BaseCommand, IRequest<ErrorResponse>
    {
        public int BoardId { get; set; }
        public string TaskName { get; set; }
        public DateTime PredictedFinishDate { get; set; }
        public PriorityLevel Priority { get; set; }
    }
}
