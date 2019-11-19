namespace Lab2.Server.Interfaces
{
    using Accounting.Service.Interfaces;

    using Lab2.Models;

    public interface IRequestCommand
    {
        object Process(Message message);
    }
}
