using System.Collections.Generic;

namespace Lab2.Server
{
    using System.ComponentModel;

    using Lab2.Models;
    using Lab2.Server.Interfaces;
    using Lab2.Server.RequestCommands;

    public class RequestHandler
    {
        private readonly Dictionary<CommandType, IRequestCommand> _commands =
            new Dictionary<CommandType, IRequestCommand>()
                {
                    { CommandType.GetAllRow, new GetAllFuelRowCommand() },
                    { CommandType.DeleteRow, new DeleteFuelRowCommand() }
                };

        public object HandleRequest(Message request)
        {
            
            this._commands.TryGetValue(request.Type, out IRequestCommand command);
            if (command is null)
            {
                throw new InvalidEnumArgumentException();
            }

            return command.Process(request);
        }
    }
}
