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
using Xceed.Wpf.AvalonDock.Layout;

namespace Fixed_management
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            C1.WPF.C1Window newwindow =new C1.WPF.C1Window();
            newwindow.Width = 800;
            newwindow.Height = 500;
            newwindow.Margin = new Thickness(SystemParameters.PrimaryScreenWidth/2d-250, SystemParameters.PrimaryScreenHeight/2d-250, 0, 0);
            newwindow.Show();
            fixedadd newfixedadd = new fixedadd();
            newwindow.Content = newfixedadd;

            //newwindow.Header = "资产增加";
            //StackPanel newstackpanel = new StackPanel();
            //Label barcode = new Label();
            //barcode.Content = "资产条码";
            //newstackpanel.Children.Add(barcode);
            //TextBox barcodetxt = new TextBox();
            //barcodetxt.Margin = new Thickness(35, 0, 0, 0);
            //barcodetxt.HorizontalAlignment = HorizontalAlignment.Left;
            //barcodetxt.Width = 80;
            //barcodetxt.Height = 26;
            //newstackpanel.Children.Add(barcodetxt);
            //newwindow.Content = newstackpanel;

        }


        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

            LayoutDocument newreport = new LayoutDocument();
            newreport.Title = "测试";
            mainpanel.Children.Add(newreport);
        }
    }
}
