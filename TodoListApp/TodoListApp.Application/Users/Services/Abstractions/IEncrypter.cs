namespace TodoListApp.Application.Users.Services.Abstractions
{
    public interface IEncrypter
    {
        string Encrypt(string text);
    }
}
