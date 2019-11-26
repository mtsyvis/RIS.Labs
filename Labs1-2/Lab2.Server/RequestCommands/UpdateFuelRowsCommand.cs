namespace Lab2.Server.RequestCommands
{
    using System.Collections.Generic;

    using Lab2.Models;
    using Lab2.Server.Interfaces;

    public class UpdateFuelRowsCommand : FuelRowRequestHandler, IRequestCommand
    {
        public override object Process(Message message)
        {
            var rows = message.Content as List<FuelRow>;
            this._repository.Update(rows);

            return null;
        }
    }
}
