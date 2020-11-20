using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODODesktopUI.ViewsModels
{
    class MyTodosViewModel
    {

        private string _newTodo = "Hello World";

        public string NewTodo
        {
            get { return _newTodo; }
            set { _newTodo = value; }
        }

    }
}
