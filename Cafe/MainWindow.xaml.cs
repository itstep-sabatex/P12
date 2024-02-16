using Cafe.Data;
using Cafe.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
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
        ObservableCollection<Waiter> waiters; 
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new CafeDbContext())
            {
                var orders = context.Orders.Include("ClientTable").Include("Waiter").ToArray();
                foreach (var order in orders)
                {
                    var s = order.ClientTable.Id;
                }
               
            }





            //using (var context = new CafeDbContext())
            //{
            //    var Waiter = context.Waiters.First(s => s.Name == "Peter Maco");



            //    var order = new Order()
            //    {
            //        ClientTable = new ClientTable() { Name = "BOSS" },
            //        Waiter = context.Waiters.First(s => s.Name == "Peter Maco"),
            //        Date = DateTime.Parse("01.01.2020")
            //    };
            //    context.Orders.Add(order);
            //    order = new Order()
            //    {
            //        ClientTable = new ClientTable() { Name = "BOSS2" },
            //        Waiter = context.Waiters.First(s => s.Name == "Peter Maco"),
            //        Date = DateTime.Parse("01.01.2020")
            //    };
            //    context.Orders.Add(order);

            //    context.SaveChanges();

            //    var clientTable = new ClientTable() { Name="BOSS3"};
            //    context.ClientTables.Add(clientTable); 
            //    context.SaveChanges();

            //    var waiter = context.Waiters.First(s => s.Name == "Peter Maco");
            //    order = new Order()
            //    {
            //        ClientTable = clientTable,
            //        Waiter = waiter,
            //        Date = DateTime.Parse("01.01.2020")
            //    };
            //    context.Add(order);
            //    order = new Order()
            //    {
            //        ClientTable = clientTable,
            //        Waiter = waiter,
            //        Date = DateTime.Parse("01.02.2020")
            //    };
            //    context.Add(order);
            //    context.SaveChanges();


            //    //context.ClientTables.Add(clientTable);


            //    //var waiter = new Waiter { Name = "Peter Maco", Birthday = DateTime.Parse("01.01.2000") };
            //    //context.Waiters.Add(waiter);
            //    //context.SaveChanges();
            //}
            ////using (var context = new CafeDbContext())
            //{
            //    var waiters =  context.Waiters.Where(s=>s.Name=="Peter Maco").ToArray();
            //    foreach (var waiter in waiters) { context.Waiters.Remove(waiter); }
            //    context.SaveChanges();
            //}

            //using (var context = new CafeDbContext())
            //{
            //    var waiters =  context.Waiters.Where(s=>s.Name=="Peter Maco").ToArray();
            //    foreach (var waiter in waiters) { waiter.Birthday = DateTime.Now; }
            //    context.SaveChanges();
            //    this.waiters = new ObservableCollection<Waiter>(waiters);
            //    dg.ItemsSource = this.waiters;
            //}

            //using (var context = new CafeDbContext())
            //{
            //    var waiter = new Waiter { Name = "Peter Maco 2", Birthday = DateTime.Parse("01.01.2000") };
            //    context.Waiters.Add(waiter);
            //    context.SaveChanges();
            //    this.waiters.Add(waiter);
            //}



        }
    }
}