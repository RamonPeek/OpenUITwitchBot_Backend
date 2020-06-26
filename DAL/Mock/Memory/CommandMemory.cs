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
            data.Add(new Command(0, "text0"));
            data.Add(new Command(1, "text1"));
            data.Add(new Command(2, "text2"));
            data.Add(new Command(3, "text3"));
            Memory = data;
        }
    }
}
