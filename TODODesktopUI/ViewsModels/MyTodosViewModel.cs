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

        private ObservableCollection<Todo> _todolist;
        public ObservableCollection<Todo> Todolist
        {
            get { return _todolist; }
            set 
            { 
                _todolist = value;
                
                //RaisePropertyChanged("Title"); 

            }
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
        // public Todo SelectedTodo { get; set; }

        private Todo _selectedTodo;

        public Todo SelectedTodo
        {
            get { return _selectedTodo; }
            set { 
                _selectedTodo = value;
            }
        }


        public RelayCommand AddTodoCommand { get; set; }
        public RelayCommand EditTodoCommand { get; set; }
        public RelayCommand DeleteTodoCommand { get; set; }
        public RelayCommand<string> SaveEditTodoCommand { get; set; }

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

        private void EditTodo()
        {

            Messenger.Default.Send(new NotificationMessage("ShowModal"));

            //EditModalView editWindow = new EditModalView();
            //editWindow.ShowDialog();
            //Console.WriteLine(SelectedTodo.Title);

        }

       

        private void SaveEditTodo(string parameter)

        {
            // Close window
                Messenger.Default.Send(new NotificationMessage("CloseModal"));

            // TODO :  Update ObservableCollection & find a way to identify correct todo that don't rely on SelectedItem



                // Hack Remove and Add a new todo (only to setup a better way to identify current todo
                // Todolist.Remove();
                //Todolist.Add(new Todo { Title = parameter }); // Update Correctly



            //var item = Todolist.FirstOrDefault(x => x.Title == "Todo 1");
            //item.Title = parameter;
            //Console.WriteLine(SelectedTodo.Title);
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