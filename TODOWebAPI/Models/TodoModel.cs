using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODOWebAPI.Models
{
    public class TodoModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; } = false;

        public TodoModel(int id, string title, bool isCompleted)
        {
            this.Id = id;
            this.Title = title;
            this.IsCompleted = isCompleted;
        }
    }
}