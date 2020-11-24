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
using TODODesktopUI.Views;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using TODODesktopUI.Helpers;

namespace TODODesktopUI.ViewsModels
{
    class MyTodosViewModel : ViewModelBase
    {
        
        private ObservableCollection<Todo> _todos;
        private Todo _selectedTodo;
        private string _newTodoTitle;

        private ICommand _editTodoCommand;
        private ICommand _deleteTodoCommand;
        private ICommand _addTodoCommand;

        public ObservableCollection<Todo> Todos
        {
            get => _todos;
            set => Set(ref _todos, value);
        }

        public Todo SelectedTodo
        {
            get => _selectedTodo;
            set => Set(ref _selectedTodo, value);
        }

        public string NewTodoTitle
        {
            get => _newTodoTitle;
            set => Set(ref _newTodoTitle, value);
        }

        public ICommand EditTodoCommand => _editTodoCommand ?? (_editTodoCommand = new RelayCommand<Todo>(EditTodo, true));

        public ICommand DeleteTodoCommand => _deleteTodoCommand ?? (_deleteTodoCommand = new RelayCommand<Todo>(DeleteTodo, true));

        public ICommand AddTodoCommand => _addTodoCommand ?? (_addTodoCommand = new RelayCommand(AddTodo, CanAddTodo));

        public MyTodosViewModel()
        {
            // Initialize instance of todolist
            Todos = new ObservableCollection<Todo>();

            // Load demo data
            Todos.Add(new Todo() { Title = "Todo 1", IsCompleted = true });
            Todos.Add(new Todo() { Title = "Todo 2", IsCompleted = false });
            Todos.Add(new Todo() { Title = "Todo 3", IsCompleted = true });

        }

        private bool CanAddTodo()
        {
            // return !String.IsNullOrWhiteSpace(NewTodoTitle);
            return true;
        }

        private void AddTodo()
        {
            Todos.Add(new Todo(_newTodoTitle)); // IMPORTANT : Shouldn't it be NewTodoTitle ?
            NewTodoTitle = string.Empty;
        }

        private void DeleteTodo(Todo todo)
        {
            Todos.Remove(todo);
        }

        private EditModalView EditModalView { get; set; }

        private void EditTodo(Todo todo)
        {

            var returnedTodo = SdbtDialogService.Instance.OpenEditModalView(todo);

            if (returnedTodo != null)
            {
                var editedTodo = Todos.FirstOrDefault(t => t.Id == returnedTodo.Id);
                if (todo != null)
                {
                    editedTodo.Title = returnedTodo.Title;
                }
                Todos = new ObservableCollection<Todo>(_todos);

            }

        }

    }
}


















