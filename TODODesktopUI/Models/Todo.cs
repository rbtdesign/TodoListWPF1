using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TODODesktopUI.Models
{
    public class Todo
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; } = false;

        //public static int Counter { get; set; }

        public Todo()
        {

        }

        public Todo(string title, int id)
        {
            Title = title;
            Id = id;
        }

        public Todo(Todo todo)
        {
            Title = todo.Title;
            IsCompleted = todo.IsCompleted;
            Id = todo.Id;
        }

    }

}
