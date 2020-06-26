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
            data.Add(new Command("shddgsagd", "text0"));
            data.Add(new Command("sdasgfdsg", "text1"));
            data.Add(new Command("bvcbvcbbc", "text2"));
            data.Add(new Command("bvcbvchff", "text3"));
            Memory = data;
        }
    }
}
