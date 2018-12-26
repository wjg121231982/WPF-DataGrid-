using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF中DataGrid控件的基础应用总结
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<Customer> list = InitCustomerData.InitData();  // 向容器中添加数据
            this.DG1.DataContext = list;
        }
    }
    public class InitCustomerData
    {
       
        
    
internal static ObservableCollection<Customer> InitData()
        {
            ObservableCollection<Customer> list = new ObservableCollection<Customer>();

            for (int i = 0; i < 10; i++)
            {
                Customer customer = new Customer();
                customer.FirstName = "a"+i.ToString ();
                customer.LastName = "a" + i.ToString();
                 UriBuilder uri;
                 uri = new UriBuilder("http://b.c/d/e.f");

                 customer.Email = uri.Uri;
                customer.IsMember = false;
                list.Add(customer);

            } 

            return list;
}
    
    }
    public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Uri Email { get; set; }
    public bool IsMember { get; set; }
}

}
