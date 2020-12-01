using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODODesktopUI.Library;
using TODODesktopUI.Views;
using TODODesktopUI.ViewsModels;

namespace TODODesktopUI.Helpers
{
    public class DialogService
    {

        private static volatile DialogService _instance;
        private static object _syncroot = new object();
        private EditModalView EditModalView { get; set; }

        private DialogService()
        {

        }

        public static DialogService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncroot)
                    {
                        if (_instance == null)
                        {
                            _instance = new DialogService();
                        }
                    }
                }
                return _instance;
            }
        }
      

        public Todo OpenEditModalView(Todo todo)
        {
            EditModalViewModel viewmodel = new EditModalViewModel(todo);
            EditModalView = new EditModalView
            {
                DataContext = viewmodel 
            };

            EditModalView.ShowDialog();

            return viewmodel.ReturnedTodo;
        }

        public void CloseEditModalView()
        {
            EditModalView.Close();
        }

        //// Extra code for futur ref : 
        //public void ShowMessageBox(string message)
        //{
        //    MessageBox.Show(message);
        //}

        //public void ShowErrorBox(string message, bool isLogged = true)
        //{
        //    if (isLogged)
        //    {
        //        MessageBox.Show($"{message} (Check logfile at {AppDomain.CurrentDomain.BaseDirectory}logs)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //    else
        //    {
        //        MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        //public bool ShowConfirmDialog()
        //{
        //    var messageBoxResult = MessageBox.Show("Are you sure you want to remove the selected record?", "Delete item",
        //        MessageBoxButton.YesNo, MessageBoxImage.Exclamation);

        //    return messageBoxResult == MessageBoxResult.Yes;
        //}

        //public string ShowOpenFileDialog()
        //{
        //    var dialog = new OpenFileDialog
        //    {
        //        DefaultExt = ".xlsx",
        //        Filter = "Excel Files (*.xlsx)|*.xlsx"
        //    };
        //    bool? result = dialog.ShowDialog();

        //    return result == true ? dialog.FileName : null;
        //}



    }
}
