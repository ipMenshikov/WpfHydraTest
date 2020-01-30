using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Threading;

namespace HydraTest
{
    /// <summary>
    /// Логика взаимодействия для WpfTestControl.xaml
    /// </summary>
    public partial class WpfTestControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DateTime Time
        {
            get { return DateTime.Now; }
        }
        public WpfTestControl()
        {
            InitializeComponent();
            DataContext = this;
            DispatcherTimer timer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
            timer.Tick += (s, e) =>
            {
                NotifyPropertyChanged("Time");
            };
            timer.Start();
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
