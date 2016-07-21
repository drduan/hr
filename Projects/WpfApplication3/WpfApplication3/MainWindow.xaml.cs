using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace WpfApplication3
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 

    public class Person
    {

        public String firstName { set; get; }
        public String lastName { set; get; }


    }

   
    
    public partial class MainWindow : Window
    {
        //List<Person> studentList = null;
        public List<Person> studentList { set; get; }
        public delegate void initdata();

        
        public MainWindow()
        {
            this.AllowsTransparency = false;
            InitializeComponent();
            pg1.Maximum = 100;
            pg1.Value = 80;
            new Task(() =>
           {
               initdata id = initData;
               IAsyncResult dl = id.BeginInvoke(null, null);
               while (!dl.IsCompleted) ;
               MessageBox.Show("数据加载成功！");
           }).Start();
            //Button1.Content = "22";

            // Console.Read();
            //while(!dl.IsCompleted)
            //{
            //    MessageBox.Show("数据加载成功！");

            //}
        }


        public void initData()
        {
            Thread.Sleep(3000);
            string text = File.ReadAllText(@"C:\a.json");
            System.Diagnostics.Trace.WriteLine("导入文件..." + text);
            JObject json = (JObject)JsonConvert.DeserializeObject(text);
            JArray array = (JArray)json["employees"];
            studentList = new List<Person>();
            foreach (JObject jobject in array)
            {
                Person p = new Person();
                p.firstName = "" + jobject["firstName"];
                p.lastName = "" + jobject["lastName"];

                studentList.Add(p);

            }
        }


        protected override void OnClosed(EventArgs e)
        {


            MessageBox.Show("close");


            //System.Diagnostics.Trace.WriteLine("系统关闭");



        }
        private void lvList_Click_1(object sender, RoutedEventArgs e)
        {

            GridViewColumn clickedColumn = (e.OriginalSource as GridViewColumnHeader).Column;

            MessageBox.Show("header" + clickedColumn.Header);

            if (clickedColumn != null)

            {
                //Get binding property of clicked column

                string bindingProperty = (clickedColumn.DisplayMemberBinding as Binding).Path.Path;
                //获得listview项是如何排序的
                SortDescriptionCollection sdc = this.ListView1.Items.SortDescriptions;

                //按升序进行排序
                ListSortDirection sortDirection = ListSortDirection.Ascending;
                if (sdc.Count > 0)
                {
                    SortDescription sd = sdc[0];
                    sortDirection = (ListSortDirection)((((int)sd.Direction) + 1) % 2);
                    sdc.Clear();
                }
                sdc.Add(new SortDescription(bindingProperty, sortDirection));
            }



        }

     

        private void Button_Click(object sender, RoutedEventArgs e)
        {




            //Thread.Sleep(9000);
            //ListView1.ItemsSource = studentList;
            //this.ListView1.DisplayMemberPath = "firstName";

            //MessageBox.Show(""+studentList.Count);
            //foreach(Person p in studentList)
            //{

            //    ListView1. Items.Add(p.firstName);
            //    ListView1.Items.Add(p.lastName);


            //}
            ListView1.DataContext = studentList;
            ListView1.Items.Refresh();
            //Task task = Task.Factory.StartNew(delegate { converttexttopersonlist(); });


        }








        private void StuSort(ListView lv, string sortBy, ListSortDirection direction)
        {

            ICollectionView dataView = CollectionViewSource.GetDefaultView(lv.ItemsSource);//获取数据源视图
            dataView.SortDescriptions.Clear();//清空默认排序描述
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);//加入新的排序描述
            dataView.Refresh();//刷新视图
        }



        public void Write(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write("Hello World!!!!");
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }



        public static void gets()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=127.0.0.1.;database=USER;uid=sa;pwd=123456";
            con.Open();
        }

        private void asd(object sender, RoutedEventArgs e)
        {
            object o = new Object();
            o = ListView1.SelectedItem;
            if (o == null)
            {
                return;
            }
            else
            {

                ListViewItem item = o as ListViewItem;
                MessageBox.Show("" + sender.GetType());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //refresh
            Button1.Content = "123";
            MessageBox.Show("OK");










        }
    }
}

//Window 有几个重要的事件：他们调用的顺序是： Window.Initialized Window.Activatied Window.Loaded Window.ContentRendered Window.DeActivatied Window.Closing Window.UnLoad Window.Closed Window.Activatied可能会与Window.DeActivatied 切换多次(窗体切换的时候发生)