namespace Lab2.Server.RequestCommands
{
    using Lab2.Models;
    using Lab2.Server.Interfaces;

    public class DeleteFuelRowCommand : FuelRowRequestHandler, IRequestCommand
    {
        public override object Process(Message message)
        {
            var fuelRow = (FuelRow)message.Content;

            this._repository.Delete(fuelRow);

            return null;
        }
    }
}
