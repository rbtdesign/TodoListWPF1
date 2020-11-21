using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODODesktopUI.Library;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace TODODesktopUI.ViewsModels
{
    class MyTodosViewModel : ViewModelBase
    {

        private ObservableCollection<Todo> _todolist;
        public ObservableCollection<Todo> Todolist
        {
            get { return _todolist; }
            set { _todolist = value; }
        }

        private string _newTodo;
        public string NewTodo
        {
            get { return _newTodo; }
            set { 
                _newTodo = value;
                
                RaisePropertyChanged();

                AddTodoCommand.RaiseCanExecuteChanged();

            }
        }
        public Todo SelectedTodo { get; set; }

        public RelayCommand AddTodoCommand { get; set; }
        public RelayCommand EditTodoCommand { get; set; }
        public RelayCommand DeleteTodoCommand { get; set; }

        public MyTodosViewModel()
        {
            // Initialize instance of todolist
            Todolist = new ObservableCollection<Todo>();

            // Load demo data
            Todolist.Add(new Todo() { Title = "Todo 1", IsCompleted=true});
            Todolist.Add(new Todo() { Title = "Todo 2", IsCompleted=false});
            Todolist.Add(new Todo() { Title = "Todo 3", IsCompleted=true});

            // Load Command for Button actions
            AddTodoCommand = new RelayCommand(AddTodo, CanAddTodo);
            
            EditTodoCommand = new RelayCommand(EditTodo);
            DeleteTodoCommand = new RelayCommand(DeleteTodo);

        }

        private bool CanAddTodo()
        {
            return !String.IsNullOrWhiteSpace(NewTodo);
        }

        private void AddTodo()
        {
            Todolist.Add(new Todo() { Title = NewTodo });
            NewTodo = String.Empty;
        }

        private void DeleteTodo()
        {
            Todolist.Remove(SelectedTodo);
        }

        private void EditTodo()
        {
            MessageBox.Show("Next feature to be implemented");
        }

        
    }
}
