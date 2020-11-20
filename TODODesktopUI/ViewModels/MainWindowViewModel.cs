using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TODODesktopUI.Library;
using TODODesktopUI.Views;

namespace TODODesktopUI.ViewModels
{
    public class MainWindowViewModel
    {


        private string _myString = "Hello World";

        public string MyString
        {
            get { return _myString; }
            set { _myString = value; }
        }



        //List<Todo> items = new List<Todo>();

        //public MainWindowViewModel()
        //{
        //    // Load demo data
        //    items.Add(new Todo() { Title = "Todo 1", IsCompleted = true });
        //    items.Add(new Todo() { Title = "Todo 2", IsCompleted = false });
        //    items.Add(new Todo() { Title = "Todo 3", IsCompleted = true });

        //    //Load initial data
        //    Todos.ItemsSource = items;
        //}

        //private void AddTodo(object sender, RoutedEventArgs e)
        //{
        //    if (NewTodo.Text.Trim() != "")
        //    {
        //        items.Add(new Todo() { Title = NewTodo.Text });

        //        //Refresh data
        //        Todos.ItemsSource = null;
        //        Todos.ItemsSource = items;

        //        NewTodo.Text = String.Empty;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Todo description is mandatory");
        //    }


        //}

        //private void RemoveTodo(object sender, RoutedEventArgs e)
        //{
        //    items.Remove((Todo)Todos.SelectedItem);

        //    //Refresh data
        //    Todos.ItemsSource = null;
        //    Todos.ItemsSource = items;
        //}

        //private void EditTodo(object sender, RoutedEventArgs e)
        //{

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

        //}

    }
}
