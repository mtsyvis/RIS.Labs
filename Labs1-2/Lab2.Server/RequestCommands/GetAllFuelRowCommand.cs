namespace Lab2.Server.RequestCommands
{
    using Lab2.Models;
    using Lab2.Server.Interfaces;

    public class GetAllFuelRowCommand : FuelRowRequestHandler, IRequestCommand
    {
        public override object Process(Message message)
        {
            var answer = this._repository.GetAll();
            return new Message() { Type = CommandType.GetAllRow, Content = answer };
        }
    }
}
