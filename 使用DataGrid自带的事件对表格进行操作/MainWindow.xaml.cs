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

namespace 使用DataGrid自带的事件对表格进行操作
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<DataGridWithEvent> list ;//= InitDataGridWithEventData.InitData();
        public MainWindow()
        {
            InitializeComponent();
           
            this.CustomerDataGrid_AddEvent.DataContext = list;

            // 以下是表格事件;
            this.CustomerDataGrid_AddEvent.BeginningEdit += CustomerDataGrid_AddEvent_BeginningEdit;              // 事件一：单元格开始编辑事件;
           // this.CustomerDataGrid_AddEvent.SelectionChanged += CustomerDataGrid_AddEvent_SelectionChanged;        // 事件二：单元格选择出现变化时;
          //  this.CustomerDataGrid_AddEvent.GotFocus += CustomerDataGrid_AddEvent_GotFocus;                        // 事件三：DataGrid表格点击单元格获取焦点时;

            // 以下是鼠标事件;
          //  this.CustomerDataGrid_AddEvent.MouseMove += CustomerDataGrid_AddEvent_MouseMove;                      // 事件四：鼠标移动到某个单元格上时触发（实验函数增加了鼠标拖动效果）;
          //  this.CustomerDataGrid_AddEvent.GotMouseCapture += CustomerDataGrid_AddEvent_GotMouseCapture;          // 事件五：使用这个事件事件鼠标拖拽更加稳定;

         //   this.CustomerDataGrid_AddEvent.MouseLeftButtonDown += CustomerDataGrid_AddEvent_MouseLeftButtonDown;  // 事件六：鼠标左键点击事件，这个事件只针对DataGrid整个表格;
         //   this.CustomerDataGrid_AddEvent.MouseEnter += CustomerDataGrid_AddEvent_MouseEnter;                    // 事件七：鼠标进入整个表格时触发，且只触发一次;

            // 另一个元素接收鼠标拖拽事件;
         //   this.ReceiveDataLabel.AllowDrop = true;
         //   this.ReceiveDataLabel.Drop += ReceiveDataLabel_Drop;
        }

        private void CustomerDataGrid_AddEvent_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {

        }
        

    }
    public class GridCell
{
    public string name { get; set; }
    public void EditingCalback()
    {
        Console.WriteLine("GridCell Editing Callback:" + name);
    }
}
    public class DataGridWithEvent
{
    public GridCell column1 { get; set; }       // 向单元格填写自定义个类型;
    public GridCell column2 { get; set; }       // 向单元格填写自定义个类型;
    public GridCell column3 { get; set; }       // 向单元格填写自定义个类型;

    // 当表格控件被编辑时，会调用单元格自身实例对应的函数;
    public void JudegePropertyCall_CellEditing(string colHeader)
    {
        switch(colHeader)
        {
            case "Column1":
                this.column1.EditingCalback();
                break;

            case "Column2":
                this.column2.EditingCalback();
                break;

            case "Column3":
                this.column3.EditingCalback();
                break;

            default:
                break;
        }
    }

}


}
