﻿using System;
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
        List<Todo> items = new List<Todo>();

        public MainWindow()
        {
            InitializeComponent();

            // Load demo data
            items.Add(new Todo() { Title = "Todo 1", IsChecked = true });
            items.Add(new Todo() { Title = "Todo 2", IsChecked = false });
            items.Add(new Todo() { Title = "Todo 3", IsChecked = true });

            //Load initial data
            Todos.ItemsSource = items;
        }



        private void AddTodo(object sender, RoutedEventArgs e)
        {
            if( newTodo.Text.Trim() != "")
            {
                items.Add(new Todo() { Title = newTodo.Text });

                //Refresh data
                Todos.ItemsSource = null;
                Todos.ItemsSource = items;
            } else
            {
                MessageBox.Show("Todo description is mandatory");
            }

          
        }

    }
}
