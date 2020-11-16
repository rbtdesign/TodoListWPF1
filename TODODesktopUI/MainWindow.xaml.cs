using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TODODesktopUI.Library;

namespace TODODesktopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Todo newTodoItem = new Todo();
        List<Todo> items = new List<Todo>();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = newTodoItem;

            // Demo Data
            items.Add(new Todo() { Title = "Todo 1" });
            items.Add(new Todo() { Title = "Todo 2" });
            items.Add(new Todo() { Title = "Todo 3" });

            Todos.ItemsSource = items;
        }

        private void AddTodo(object sender, RoutedEventArgs e)
        {
            string str = newTodoItem.Title;
            items.Add(new Todo() { Title = str });

            //Refresh data
            Todos.ItemsSource = null;
            Todos.ItemsSource = items;
        }
    }
}
