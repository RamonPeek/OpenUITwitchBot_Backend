using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mock.Memory
{
    public class CommandMemory
    {
        public static List<Command> Memory { get; }

        static CommandMemory()
        {
            List<Command> data = new List<Command>();
            data.Add(new Command("shddgsagd", "!cmd0", CommandType.CHAT_REPLY, "Executed cmd0"));
            data.Add(new Command("sdasgfdsg", "!cmd1", CommandType.CHAT_REPLY, "Executed cmd1"));
            data.Add(new Command("bvcbvcbbc", "!cmd2", CommandType.CHAT_REPLY, "Executed cmd2"));
            data.Add(new Command("bvcbvchff", "!cmd3", CommandType.CHAT_REPLY, "Executed cmd3"));
            Memory = data;
        }
    }
}
