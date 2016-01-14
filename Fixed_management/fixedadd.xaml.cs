using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Fixed_management
{
    /// <summary>
    /// fixedadd.xaml 的交互逻辑
    /// </summary>
    public partial class fixedadd : UserControl
    {
        public fixedadd()
        {
            InitializeComponent();
        }
        public string selectedText;
        private void barcode_btn_Click(object sender, RoutedEventArgs e)
        {
          

        }

        private void nature_btn_Click(object sender, RoutedEventArgs e)
        {


            C1.WPF.C1Window newnature = new C1.WPF.C1Window();
            newnature.Name = "newnature";
            newnature.Width = 400;
            newnature.Height = 500;
            newnature.Margin = new Thickness(SystemParameters.PrimaryScreenWidth / 2d - 250, SystemParameters.PrimaryScreenHeight / 2d - 250, 0, 0);
            newnature.ShowModal();
            Canvas newstackpanel = new Canvas();
          
            newnature.Content = newstackpanel;
            ListBox naturelist = new ListBox();
            naturelist.Width = 390;
            naturelist.Height = 400;
            //naturelist.VerticalAlignment = VerticalAlignment.Top;
            //naturelist.HorizontalAlignment = HorizontalAlignment.Left;
            naturelist.Items.Add("abc");
            Button quedin = new Button();
            quedin.Content = "确定";
            quedin.Width = 80;
            quedin.Height = 30;
            //quedin.HorizontalAlignment = HorizontalAlignment.Left;
            quedin.Margin = new Thickness(80, 420, 0, 0);

            Button quxiao = new Button();
            quxiao.Content = "取消";
            quxiao.Width = 80;
            quxiao.Height = 30;
            //quxiao.HorizontalAlignment = HorizontalAlignment.Left;
            quxiao.Margin = new Thickness(250, 420, 0, 0);
            newstackpanel.Children.Add(naturelist);
            newstackpanel.Children.Add(quedin);
            newstackpanel.Children.Add(quxiao);
            naturelist.SelectionChanged += new SelectionChangedEventHandler(naturelist_SelectionChanged);
            quedin.Click += new RoutedEventHandler(quedin_Click);
         
           
        }

        void quedin_Click(object sender, RoutedEventArgs e)
        {
            C1.WPF.C1Window newnature = MainWindow.FindChild<C1.WPF.C1Window>(Application.Current.MainWindow, "newnature");
            nature_txt.Text = selectedText;
            newnature.Close();
            
        }
        void quxiao_Click(object sender, RoutedEventArgs e)
        {
            
        }

        void naturelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             selectedText = (sender as ListBox).SelectedItem.ToString();
        }

        private void textBox16_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
