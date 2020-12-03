using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TODODesktopUI.Helpers;
using TODODesktopUI.Library;
using TODODesktopUI.Views;

namespace TODODesktopUI.ViewsModels
{
    public class EditModalViewModel : ViewModelBase
    {
        private Todo _todo;
        private Todo _returnedTodo;

        private ICommand _saveEditTodoCommand;

        public Todo Todo
        {
            get => _todo;
            set => Set(ref _todo, value);
        }

        public Todo ReturnedTodo
        {
            get => _returnedTodo;
            set => Set(ref _returnedTodo, value);
        }

        public ICommand SaveEditTodoCommand => _saveEditTodoCommand ?? (_saveEditTodoCommand = new RelayCommand(SaveEditTodo));


        public EditModalViewModel(Todo todo)
        {
            Todo = new Todo(todo);
        }

        private void SaveEditTodo()
        {
            _returnedTodo = new Todo(_todo);

            DialogService.Instance.CloseEditModalView();
        }
    }
}
