using System;
using System.Collections.ObjectModel;
using TODODesktopUI.Library;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using TODODesktopUI.Helpers;
using TODODesktopUI.Services;

namespace TODODesktopUI.ViewsModels
{
    public class MyTodosViewModel : ViewModelBase
    {
        private ObservableCollection<Todo> _todos;
        private string _newTodoTitle;

        private readonly ITodosService _todosService;

        private ICommand _addTodoCommand;
        private ICommand _editTodoCommand;
        private ICommand _editCheckBoxCommand;
        private ICommand _deleteTodoCommand;

        public ObservableCollection<Todo> Todos
        {
            get => _todos;
            set => Set(ref _todos, value);
        }

        public string NewTodoTitle
        {
            get => _newTodoTitle;
            set => Set(ref _newTodoTitle, value);
        }

        public ICommand AddTodoCommand => _addTodoCommand ?? (_addTodoCommand = new RelayCommand(AddTodo, CanAddTodo));
        public ICommand EditTodoCommand => _editTodoCommand ?? (_editTodoCommand = new RelayCommand<Todo>(EditTodo, true));
        public ICommand EditCheckBoxCommand => _editCheckBoxCommand ?? (_editCheckBoxCommand = new RelayCommand<Todo>(EditCheckbox, true));
        public ICommand DeleteTodoCommand => _deleteTodoCommand ?? (_deleteTodoCommand = new RelayCommand<Todo>(DeleteTodo, true));

        public MyTodosViewModel(ITodosService todosService)
        {
            // Initialize http client 
            ApiHelper.InitializeClient();

            _todosService = todosService;

            GetTodos();
        }

        private async void GetTodos()
        {
            var todolist = await _todosService.GetAll();
            Todos = new ObservableCollection<Todo>(todolist);
        }

        private bool CanAddTodo()
        {
            return !String.IsNullOrWhiteSpace(_newTodoTitle);
            //return true;
        }

        private async void AddTodo()
        {
            Todo todo = await _todosService.Create(_newTodoTitle);

            Todos.Add(todo);
            NewTodoTitle = string.Empty;
       
        }

        private async void DeleteTodo(Todo todo)
        {
            bool isConfirmed = DialogService.Instance.ShowConfirmDialog();

            if(isConfirmed)
            {
                bool isDeleted = await _todosService.Delete(todo.Id);
                if (isDeleted)
                    Todos.Remove(todo);
            }

        }

        private async void EditTodo(Todo todo)
        {
            var returnedTodo = DialogService.Instance.OpenEditModalView(todo);

            if (returnedTodo != null)
            {
                var todolist = await _todosService.Update(returnedTodo);
                Todos = new ObservableCollection<Todo>(todolist);
            }

        }

        private async void EditCheckbox(Todo todo)
        {

            var todolist = await _todosService.Update(todo);
            Todos = new ObservableCollection<Todo>(todolist);
        }

    }
}


















