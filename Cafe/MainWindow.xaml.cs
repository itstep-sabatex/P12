﻿using Cafe.Models;
using Cafe.ViewModels;
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


        private void AddOrder(object sender, RoutedEventArgs e)
        {
            //mainForm.Visibility = Visibility.Collapsed;
            //orderEdit.ShowOrderEdit(mainForm);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var r = CafeArchive.CreateArchive(Config.DbContext);
 
            //using (var context = Config.DbContext)
            //{
            //    var waiters = context.Waiters.Include("Orders").Where(s=>s.Name.StartsWith("Pt")).Select(sl=> new {sl.Name,sl.Id}).ToArray();

            //    var orders = context.Orders.Include("ClientTable").Include("Waiter").ToArray();
            //    foreach (var order in orders)
            //    {
            //        var s = order.ClientTable.Id;
            //    }

            //}





            //using (var context = new CafeDbContext())
            //{
            //    var Waiter = context.Waiters.First(s => s.Name == "Peter Maco");



            //var order = new Order()
            //{
            //       ClientTable = new ClientTable() { Name = "BOSS" },
            //       Waiter = context.Waiters.First(s => s.Name == "Peter Maco"),
            //       Date = DateTime.Parse("01.01.2020")
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

            //var waiter = context.Waiters.First(s => s.Name == "Peter Maco");
            //var order = new Order()
            //{
            //    ClientTableId = clientTable.Id,
            //    WaiterId = waiter.Id,
            //    Date = DateTime.Parse("01.01.2020")
            //};
            // context.Add(order);
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
        private void RefreshGrid()
        {
            using (var context = Config.DbContext)
            {
                var r = context.Orders.Where(w => w.WaiterId == Config.WaiterId)
                    .Join(context.ClientTables, ws => ws.ClientTableId, ab => ab.Id, (ws, ab) => new MainWindowViewModelR(ws.Id,ws.Date.ToString("H:mm:ss"),ab.Name,ws.Bill)).ToArray();
                dg.ItemsSource = new ObservableCollection<MainWindowViewModelR>(r);
            //    //var items = context.Order.ToArray();
            //    //var s = new StringBuilder();
            //    //foreach (var v in items)
            //    //{
            //    //    var str = "new Order { Id ="
            //    //        + $" {v.Id}, WaiterId = {v.WaiterId}, AbonentId = {v.AbonentId}, TimeOrder";

            //    //    s.AppendLine("new FoodItem { Name ="+$" \"{v.Name}\",Price = {v.Price}M, Id = {v.Id}"+" },");
            //    //}
            //    //var st = s.ToString();
            //    //File.WriteAllText("sql.txt", st);
            }
        }
        private void Login_LoginResult(int? arg1, string arg2)
        {
            if (arg1 == null)
                Close();
            else
            {
                Config.WaiterId = arg1.Value;
                Config.WaiterName = arg2;
                Title = $"Офіціант {Config.WaiterName} : {DateTime.Now}";
                login.Visibility = Visibility.Hidden;
                RefreshGrid();
                mainForm.Visibility = Visibility.Visible;
            }

        }
        private void dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //mainForm.Visibility = Visibility.Collapsed;
            //var item = dg.CurrentItem as MainWindowViewModel;
            //orderEdit.ShowOrderEdit(item.id);
        }
        private void Pay_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}