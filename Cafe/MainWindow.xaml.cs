using Cafe.Data;
using Cafe.Models;
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

namespace Cafe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {



            using (var context = new CafeDbContext())
            {
                var waiter = new Waiter { Name = "Peter Maco", Birthday = DateTime.Parse("01.01.2000") };
                context.Waiters.Add(waiter);
                context.SaveChanges();
            }
            //using (var context = new CafeDbContext())
            //{
            //    var waiters =  context.Waiters.Where(s=>s.Name=="Peter Maco").ToArray();
            //    foreach (var waiter in waiters) { context.Waiters.Remove(waiter); }
            //    context.SaveChanges();
            //}

            using (var context = new CafeDbContext())
            {
                var waiters =  context.Waiters.Where(s=>s.Name=="Peter Maco").ToArray();
                foreach (var waiter in waiters) { waiter.Birthday = DateTime.Now; }
                context.SaveChanges();
                dg.ItemsSource = waiters;
            }
            
           

        }
    }
}