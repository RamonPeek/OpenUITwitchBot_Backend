using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Command
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Command() {}

        public Command(int id, string text)
        {
            this.Id = id;
            this.Text = text;
        }
    }
}
