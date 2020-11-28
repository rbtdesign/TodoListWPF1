using GalaSoft.MvvmLight.Messaging;
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

namespace TODODesktopUI.Views
{
    /// <summary>
    /// Interaction logic for MyTodosView.xaml
    /// </summary>
    public partial class MyTodosView : Window
    {
        public MyTodosView()
        {
            InitializeComponent();
           // Messenger.Default.Register<NotificationMessage>(this,NotificationMessageReceived);
        }

        //private void NotificationMessageReceived(NotificationMessage msg)
        //{
        //    if (msg.Notification == "ShowModal")
        //    {
        //        var modalWindow = new EditModalView();
        //        modalWindow.DataContext = this.DataContext;
        //        modalWindow.ShowDialog();

        //    }

        //}
    }
}
