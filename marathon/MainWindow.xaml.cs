using marathon.View.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace marathon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DateTime startTime;
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new StartPage());

            this.DataContext = this;

            startTime = DateTime.Parse("2022-12-21 12:00");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод таймера
        /// </summary>
        public void TimerDate()
        {
            System.Timers.Timer tmr = new System.Timers.Timer
            {
                Interval = 1000
            };
            tmr.Elapsed += Tmr_Elapsed;

            tmr.Start();
        }
        private void Tmr_Elapsed(object sender, ElapsedEventArgs e)
        {

            PropertyChange("Time");

        }
        private void PropertyChange(string name)
        {

            if (PropertyChanged != null)

                PropertyChanged(this, new PropertyChangedEventArgs(name));

        }
        public string Time
        {

            get

            {
                TimeSpan timeSpan = startTime - DateTime.Now;

                return string.Format("{0} дней {1} часов и {2} минут до старта марафона", timeSpan.Days, timeSpan.Hours, timeSpan.Minutes);
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            TimerDate();

        }
        private void MainFrameContentRendered(object sender, EventArgs e)
        {
            if (!MainFrame.CanGoBack)
            {
                BackButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                BackButton.Visibility = Visibility.Visible;
            }
        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }
        //private void become_runnerClick(object sender, RoutedEventArgs e)
        //{
        //    this.NavigationService.Navigate(new RegPage());
        //}
    }
}
