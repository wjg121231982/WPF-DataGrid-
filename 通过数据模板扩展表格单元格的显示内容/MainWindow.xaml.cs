using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace 通过数据模板扩展表格单元格的显示内容
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MessageVM m_MessageVM = new MessageVM();             // MessageVM层，用来显示MessageModel的;

        public MainWindow()
        {
            InitializeComponent();
            this.MsgDataGrid.DataContext = m_MessageVM.messagelist;
            // 使用一个线程更新DataGrid控件
            Task a = new Task(() =>
            {
                int temp = 0;
                while (true)
                {
                    temp = temp + 1;
                    Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                    {
                        m_MessageVM.messagelist.Add(new MessageModel()
                        {
                            m_No = temp.ToString(),
                            m_time = DateTime.Now,
                            m_content = "content",
                            m_source = "172.27.0.1",
                            m_dest = "172.27.0.2"

                        });
                    });
                    Thread.Sleep(1233);
                }
            });

            a.Start();

        }

        private void MsgDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {

        }

    }
    public class MessageModel
{
    /// <summary>
    /// 可触发的命令:显示消息内容;
    /// </summary>
    private ICommand mShowCommand;
    public ICommand ShowCommand
    {
        get
        {
            if (mShowCommand == null)
            {
                mShowCommand = new RelayCommand(() =>
                {
                    ExecuteAction();
                },
                () => CanExecuteFunc());
            }
            return mShowCommand;
        }
    }
    private bool CanExecuteFunc()
    {
        return true;
    }
    private void ExecuteAction()
    {
        Console.WriteLine("Content is" + this.m_content);
        if (this.m_content_detail==null)
        {
            return;
        }
        foreach(var iter in this.m_content_detail)
        {
            Console.WriteLine("Content Detail is " + iter);
        }
    }

    /// <summary>
    /// 消息编号;
    /// </summary>
    private string No;
    public string m_No
    {
        get { return No; }
        set { No = value; }
    }

    /// <summary>
    /// 时间戳;
    /// </summary>
    private DateTime time;
    public DateTime m_time
    {
        get { return time; }
        set { time = value; }
    }

    /// <summary>
    /// 消息内容A;
    /// </summary>
    private string content;
    public string m_content
    {
        get { return content; }
        set { content = value; }
    }

    private List<string> content_detail;
    public List<string> m_content_detail
    {
        get { return content_detail; }
        set { m_content_detail = value; }
    }
    
    /// <summary>
    /// 消息的源IP地址;
    /// </summary>
    private string source;
    public string m_source
    {
        get { return source; }
        set { source = value; }
    }

    /// <summary>
    /// 消息的目的IP地址;
    /// </summary>
    private string dest;
    public string m_dest
    {
        get { return dest; }
        set { dest = value; }
    }
}

public class RelayCommand : ICommand
{
    private Action mExecuteAction;              // 执行命令;
    private Func<bool> mCanExecuteFunc;         // 命令是否可以执行;

    public RelayCommand(Action executeAction, Func<bool> canExecuteFunc)
    {
        mExecuteAction = executeAction;
        mCanExecuteFunc = canExecuteFunc;
    }
  
    public bool CanExecute(object parameter)
    {
        return mCanExecuteFunc.Invoke();
    }

    public void Execute(object parameter)
    {
        mExecuteAction.Invoke();
    }

    public event EventHandler CanExecuteChanged;
    
}
public class MessageVM
{
    // 存放所有消息内容的地方;
    private volatile ObservableCollection<MessageModel> m_messagelist;
    public ObservableCollection<MessageModel> messagelist
    {
        get
        {
            return m_messagelist;
        }
        set
        {
            m_messagelist = value;
        }
    }

    public MessageVM()
    {
        messagelist = new ObservableCollection<MessageModel>();
    }
}

}
