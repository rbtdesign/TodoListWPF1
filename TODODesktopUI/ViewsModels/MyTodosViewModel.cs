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

namespace TODODesktopUI.ViewsModels
{
    class MyTodosViewModel : ViewModelBase
    {

        public ObservableCollection<Todo> Todolist { get; set; }

        private string _newTodo;
        public string NewTodo
        {
            get { return _newTodo; }
            set
            {
                _newTodo = value;

                RaisePropertyChanged();

                AddTodoCommand.RaiseCanExecuteChanged();

            }
        }
        // public Todo SelectedTodo { get; set; }

        public Todo SelectedTodo { get; set; }
        public Todo CurrentTodo { get; set; }
        public RelayCommand AddTodoCommand { get; set; }
        public RelayCommand<Todo> EditTodoCommand { get; set; }
        public RelayCommand DeleteTodoCommand { get; set; }
        public RelayCommand<string> SaveEditTodoCommand { get; set; }

        public MyTodosViewModel()
        {
            // Initialize instance of todolist
            Todolist = new ObservableCollection<Todo>();

            // Load demo data
            Todolist.Add(new Todo() { Title = "Todo 1", IsCompleted = true });
            Todolist.Add(new Todo() { Title = "Todo 2", IsCompleted = false });
            Todolist.Add(new Todo() { Title = "Todo 3", IsCompleted = true });

            // Load Command for Buttons actions
            AddTodoCommand = new RelayCommand(AddTodo, CanAddTodo);

            EditTodoCommand = new RelayCommand<Todo>((currentTodo) => EditTodo(currentTodo));
            DeleteTodoCommand = new RelayCommand(DeleteTodo);
            SaveEditTodoCommand = new RelayCommand<string>((parameter) => SaveEditTodo(parameter));
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

        private void EditTodo(Todo currentTodo)
        {

            CurrentTodo = currentTodo;

            Messenger.Default.Send(new NotificationMessage("ShowModal"));

            //EditModalView editWindow = new EditModalView();
            //editWindow.DataContext = this;
            //editWindow.ShowDialog();
        }

        private void SaveEditTodo(string parameter)

        {
            // Close window
            Messenger.Default.Send(new NotificationMessage("CloseModal"));


            // Update Todo list - TEMP solution
            CurrentTodo.Title = parameter;

            Todolist.Remove(CurrentTodo);
            Todolist.Add(CurrentTodo);

        }
    }
}
























//    Todo value = (Todo)Todos.SelectedValue;

//    ModalWindow editWindow = new ModalWindow(value.Title);
//    editWindow.ShowDialog();

//    // Recover value from Modal 
//    string valueFromModal = ModalWindow.updatedTodo;

//    // Update the title
//    value.Title = valueFromModal;

//    //Refresh data
//    Todos.ItemsSource = null;
//    Todos.ItemsSource = items;


////EditModalView editTodoModal = new EditModalView();

////editTodoModal.ShowDialog();

//Messenger.Default.Send(new DialogMessage("test 4"));

//Messenger.Default.Send(new NotificationMessage("ShowWindow"));