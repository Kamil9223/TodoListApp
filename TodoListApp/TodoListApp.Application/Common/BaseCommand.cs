namespace TodoListApp.Application.Common
{
    public abstract class BaseCommand
    {
        public ErrorResponse ErrorModel { get; set; } = new ErrorResponse();
    }
}
