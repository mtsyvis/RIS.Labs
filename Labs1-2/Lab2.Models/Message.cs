using System;

namespace Lab2.Models
{
    [Serializable]
    public enum CommandType
    {
        GetAllRow,
        DeleteRow,
        UpdateRow,
        AddRow
    }

    [Serializable]
    public class Message
    {
        public CommandType Type { get; set; }

        public object Content { get; set; }
    }
}
