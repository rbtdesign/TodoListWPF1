using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace TODODesktopUI.Views
{
    /// <summary>
    /// Interaction logic for EditModalView.xaml
    /// </summary>
    public partial class EditModalView : Window
    {
        public EditModalView()
        {
            InitializeComponent();

            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);

        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "CloseModal")
            {
                this.Close();
            }
        }

    }
}
