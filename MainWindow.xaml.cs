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
using Wpf.Ui.Controls;

namespace GlobalHotkeys
{
    public partial class MainWindow : UiWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Visibility = Visibility.Visible;
            //TODO if modernNotifyIcon
            if (App.config!.modernNotifyIcon)
            {
                NotifyIcon icon = (NotifyIcon)FindResource("ModernNotifyIcon");
                _titleBar.Tray = icon;
            }
        }

        private void MenuItemConfiguration_Click(object sender, RoutedEventArgs e) { Event_Configure(); }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e) { Event_Exit(); }

        private void NotifyIcon_LeftClick(NotifyIcon sender, RoutedEventArgs e) { Event_LeftClick(); }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Visibility = Visibility.Hidden;
        }

        // internal events

        internal void Event_Configure()
        {
            Visibility = Visibility.Visible;
            if (WindowState == WindowState.Minimized) WindowState = WindowState.Normal;
            Activate();
        }

        internal void Event_Exit()
        {
            Application.Current.Shutdown();
        }

        internal void Event_LeftClick()
        {
            if (Visibility == Visibility.Visible) Visibility = Visibility.Hidden;
            else Visibility = Visibility.Visible;
        }
    }
}
