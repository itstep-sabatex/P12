using System.Text;
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

namespace WpfMatrixDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer a;
        Timer timer;

        public MainWindow()
        {
            InitializeComponent();
            a = new DispatcherTimer();
            a.Interval = TimeSpan.FromSeconds(0.2);
            a.Tick += A_Tick;
           
        }

        private void A_Tick(object? sender, EventArgs e)
        {
            pbInThread.Value++;
            if (pbInThread.Value == 100)
                a.Stop();
        }


        private void B_TimerTick(object? state) //Стартує  в окремому потоці 
        {
                 Dispatcher.Invoke(() =>
                {
                    //Thread.Sleep(200);
                    pbAsThread.Value++;
                    if (pbAsThread.Value == 100)
                    {
                        timer?.Dispose();
                        timer = null;
                    }
                });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pbInThread.Value = 0;
            a.Start();

            
            var result = Parallel.For(1, 100, (i, StateChanged) =>
            {
                Console.WriteLine($"Begin iterstion {i}"); 
            });


        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer = new Timer(B_TimerTick, null, 0, 200);
        }
    }
}