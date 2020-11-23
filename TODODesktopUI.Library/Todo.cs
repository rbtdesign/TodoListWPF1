using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TODODesktopUI.Library
{
    public class Todo 
    {

        public bool IsCompleted { get; set; } = false;
        public string Title { get; set; }
        public static int Counter { get; set; }
        public int Id { get; set; }


        public Todo()
        {
            Counter++;
            Id = Counter;
        }

        public Todo(string description, bool status)
        {
            Title = description;
            IsCompleted = status;
            Counter++;
            Id = Counter;
        }

    }

}
