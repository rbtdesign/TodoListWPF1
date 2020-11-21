using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODODesktopUI.Library;

namespace TODODesktopUI.ViewsModels
{
    class MyTodosViewModel
    {

        private string _newTodo = "Hello World";
        public string NewTodo
        {
            get { return _newTodo; }
            set { 
                _newTodo = value;
            
            }
        }

        private ObservableCollection<Todo> _todolist;
        public ObservableCollection<Todo> Todolist
        {
            get { return _todolist; }
            set { _todolist = value; }
        }


        public MyTodosViewModel()
        {
            // Initialize instance of todolist
            Todolist = new ObservableCollection<Todo>();

            // Load demo data
            Todolist.Add(new Todo() { Title = "Todo 1", IsCompleted=true});
            Todolist.Add(new Todo() { Title = "Todo 2", IsCompleted=false});
            Todolist.Add(new Todo() { Title = "Todo 3", IsCompleted=true});
        }

        public void AddTodo()
        {

        }
    }
}
