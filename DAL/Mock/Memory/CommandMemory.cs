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
            data.Add(new Command("shddgsagd", "!cmd0", CommandType.TEXT, "Executed cmd0"));
            data.Add(new Command("sdasgfdsg", "!cmd1", CommandType.TEXT, "Executed cmd1"));
            data.Add(new Command("bvcbvcbbc", "!cmd2", CommandType.TEXT, "Executed cmd2"));
            data.Add(new Command("bvcbvchff", "!cmd3", CommandType.TEXT, "Executed cmd3"));
            Memory = data;
        }
    }
}
