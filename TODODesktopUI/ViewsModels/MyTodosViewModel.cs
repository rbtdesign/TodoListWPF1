using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODODesktopUI.Library;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using TODODesktopUI.Views;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;
using TODODesktopUI.Helpers;
using TODODesktopUI.Models;

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
            set 
            {
                Set(ref _newTodoTitle, value);
            }
           
        }

        public ICommand EditTodoCommand => _editTodoCommand ?? (_editTodoCommand = new RelayCommand<Todo>(EditTodo, true));
        public ICommand DeleteTodoCommand => _deleteTodoCommand ?? (_deleteTodoCommand = new RelayCommand<Todo>(DeleteTodo, true));
        public ICommand AddTodoCommand => _addTodoCommand ?? (_addTodoCommand = new RelayCommand(AddTodo, CanAddTodo));

        public MyTodosViewModel()
        {
            // Initialize instance of todolist
            Todos = new ObservableCollection<Todo>();

            // Initialize http client 
            ApiService.InitializeClient();

            //Fetch inital data
            LoadTodos();
        }


        private async void LoadTodos()
        {
            var data = await TodosProcessor.GetAll();
            Todos = new ObservableCollection<Todo>(data);
        }


        private bool CanAddTodo()
        {
            return !String.IsNullOrWhiteSpace(_newTodoTitle);
            //return true;
        }

        private async void AddTodo()
        {
            Todo todo = await TodosProcessor.Create(_newTodoTitle);

            Todos.Add(todo);
            NewTodoTitle = string.Empty;
       
        }

        private async void DeleteTodo(Todo todo)
        {
            bool isDeleted = await TodosProcessor.Delete(todo.Id);
            if (isDeleted)
                Todos.Remove(todo);
        }

        private EditModalView EditModalView { get; set; }

        private async void EditTodo(Todo todo)
        {

            var returnedTodo = DialogService.Instance.OpenEditModalView(todo);

            if (returnedTodo != null)
            {
                var todolist = await TodosProcessor.Update(returnedTodo);
                Todos = new ObservableCollection<Todo>(todolist);

            }

        }

    }
}


















