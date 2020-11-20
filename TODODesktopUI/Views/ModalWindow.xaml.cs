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
using System.Windows.Shapes;
using TODODesktopUI;

namespace TODODesktopUI.Views
{
    /// <summary>
    /// Interaction logic for ModalWindow.xaml
    /// </summary>
    public partial class ModalWindow : Window
    {
        public static string updatedTodo = String.Empty;
        public ModalWindow(string oldTodo)
        {
            InitializeComponent();
            EditTodoBox.Text = oldTodo;
        }

        private void SaveNewTodo(object sender, RoutedEventArgs e)
        {
            updatedTodo = EditTodoBox.Text;
            this.Close();
        }

    }
}
