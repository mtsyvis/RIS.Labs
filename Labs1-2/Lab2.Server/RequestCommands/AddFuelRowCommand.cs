namespace Lab2.Server.RequestCommands
{
    using Lab2.Models;
    using Lab2.Server.Interfaces;

    public class AddFuelRowCommand : FuelRowRequestHandler, IRequestCommand
    {
        public override object Process(Message message)
        {
            var row = message.Content as FuelRow;
            this._repository.Add(row);

            return null;
        }
    }
}
