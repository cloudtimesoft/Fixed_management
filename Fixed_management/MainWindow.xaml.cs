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


        public string[] permsis;

        public static T FindChild<T>(DependencyObject parent, string childName)//查找控件
where T : DependencyObject
        {
            if (parent == null) return null;
            T foundChild = null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // 如果子控件不是需查找的控件类型 
                T childType = child as T;
                if (childType == null)
                {
                    // 在下一级控件中递归查找 
                    foundChild = FindChild<T>(child, childName);
                    // 找到控件就可以中断递归操作  
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // 如果控件名称符合参数条件 
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // 查找到了控件 
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }




        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            C1.WPF.C1Window findfixed = MainWindow.FindChild<C1.WPF.C1Window>(Application.Current.MainWindow, "newfixed");
            if (findfixed != null)
            {
                findfixed.IsActive = true;
            }
            else
            {
                C1.WPF.C1Window newfixed = new C1.WPF.C1Window();
                newfixed.IsResizable = false;
                newfixed.Name = "newfixed";
                newfixed.Width = 800;
                newfixed.Height = 540;
                newfixed.Header = "资产增加";
                newfixed.Margin = new Thickness(SystemParameters.PrimaryScreenWidth / 2d - 250, SystemParameters.PrimaryScreenHeight / 2d - 250, 0, 0);
                newfixed.Show();
                newfixed.ShowMaximizeButton = false;
                newfixed.ShowMinimizeButton = false;
                fixedadd newfixedadd = new fixedadd();
                newfixedadd.Name = "newfixedadd";
                newfixed.Content = newfixedadd;

            }

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


    

        private void fixed_transfers_Click(object sender, RoutedEventArgs e)
        {
            transfer findfix = MainWindow.FindChild<transfer>(Application.Current.MainWindow, "transfer");
            if (findfix != null)
            {
                foreach (var t in mainpanel.Children)
                {
                    if (t.Title == "资产转移")
                    {
                        t.IsActive = true;
                        break;
                    }
                }
            }
            else
            {
                transfer newtransfer = new transfer();
                LayoutDocument newreport = new LayoutDocument();
                newreport.Title = "资产转移";
                newreport.IsActive=true;
                newreport.Content = newtransfer;
                newtransfer.Name = "transfer";
                mainpanel.Children.Add(newreport);
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 nature 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.natureTableAdapter fixedDataSetnatureTableAdapter = new Fixed_management.FixedDataSetTableAdapters.natureTableAdapter();
            fixedDataSetnatureTableAdapter.Fill(fixedDataSet.nature);
            System.Windows.Data.CollectionViewSource natureViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("natureViewSource")));
            natureViewSource.View.MoveCurrentToFirst();

            Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter fixedDataSetemployeesTableAdapter = new Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter();
            fixedDataSetemployeesTableAdapter.Fill(fixedDataSet.employees);

            dockingManager.Height = SystemParameters.PrimaryScreenHeight - 150;


            string user = fixedDataSet.employees.FindByemployees_ID(Public.user_id).em_name;


            StackPanel newstack = new StackPanel();
            newstack.Opacity = 0.65;
            newstack.Height = 28;
           // newstack.Background = Brushes.Red;
            newstack.VerticalAlignment = VerticalAlignment.Bottom;

            TextBlock newtextblock = new TextBlock();
            newtextblock.VerticalAlignment = VerticalAlignment.Center;
            newtextblock.Height = 28;
            newtextblock.FontSize = 20;
            newtextblock.Margin = new Thickness(200, 0, 0, 0);
            newtextblock.Text ="当前登录  ：" +user;
            newstack.Children.Add(newtextblock);
            mainwindow.Children.Add(newstack);


            permissions();



        }


        private void permissions()
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            string pem = fixedDataSet.employees.FindByemployees_ID(Public.user_id).pemissions;
            permsis = pem.Split('f');



            foreach (string s in permsis)
            {
                if (s == "3")
                {
                    fix_add.IsEnabled = true;
                    fix_addtool.IsEnabled = true;
                }
                if (s == "4")
                {
                    fix_transfertool.IsEnabled = true;
                    fixed_transfers.IsEnabled = true;
                }
                if (s == "5")
                {
                    fix_outtool.IsEnabled = true;

                }
                if (s == "6")
                {
                    fix_deltool.IsEnabled = true;
                    del_fixtool.IsEnabled = true;
                }
                if (s == "7")
                {
                    information_intool.IsEnabled = true;
                }
                if (s == "8")
                {
                    fix_printool.IsEnabled = true;
                    fix_prin.IsEnabled = true;
                }
                if (s == "9")
                {

                }
                if (s == "10")
                {
                    enable_fixtool.IsEnabled = true;
                    effective_name.IsEnabled = true;
                }
                if (s == "11")
                {
                    exit_fixtool.IsEnabled = true;
                }
                if (s == "12")
                {
                    del_fixtool.IsEnabled = true;
                }
                if (s == "13")
                {
                    transfer_information_tool.IsEnabled = true;
                    transfer_information.IsEnabled = true;
                }
                if (s == "14")
                {
                    fixclass_detailtool.IsEnabled = true;

                }
                if (s == "15")
                {
                    fixclass_tal.IsEnabled = true;
                }
                if (s == "16")
                {

                }
                if (s == "17")
                {
                    fix_inventorytool.IsEnabled = true;
                    fix_inventory.IsEnabled = true;
                }
                if (s == "18")
                {
                    employees.IsEnabled = true;
                }
                if (s == "19")
                {
                    register_tool.IsEnabled = true;
                }
                if (s == "20")
                {
                    report_designtool.IsEnabled = true;
                }
                if (s == "21")
                {
                    tag_titletool.IsEnabled = true;
                }
                
            }
  
           

        }





        private void employees_Click(object sender, RoutedEventArgs e)
        {

            Userlist findemployees = MainWindow.FindChild<Userlist>(Application.Current.MainWindow, "newuserlist");
            if (findemployees != null)
            {
                foreach (var t in mainpanel.Children)
                {
                    if (t.Title == "员工管理")
                    {
                        t.IsActive = true;
                        break;
                    }
                }
            }
            else
            {
                //C1.WPF.C1Window employeeswindow = new C1.WPF.C1Window();
                //employeeswindow.Name = "employeeswindow";
                //employeeswindow.Width = 700;
                //employeeswindow.Height = 550;
                //employeeswindow.Header = "员工管理";
                //employeeswindow.Margin = new Thickness(SystemParameters.PrimaryScreenWidth / 2d - 250, SystemParameters.PrimaryScreenHeight / 2d - 250, 0, 0);
                //employeeswindow.Show();
                //employeeswindow.ShowMaximizeButton = false;
                //employeeswindow.ShowMinimizeButton = false;
                //Userlist newemployees = new Userlist();
                //newemployees.Name = "newemployees";
                //employeeswindow.Content = newemployees;

                Userlist newuserlist = new Userlist();
                newuserlist.Name = "newuserlist";
                LayoutDocument newuser = new LayoutDocument();
                newuser.Content = newuserlist;
                newuser.IsActive = true;
                newuser.Title = "员工管理";
                mainpanel.Children.Add(newuser);



            }
        }

        private void effective_name_Click(object sender, RoutedEventArgs e)
        {
            Effective findfix = MainWindow.FindChild<Effective>(Application.Current.MainWindow, "fix");
            if (findfix != null)
            {
                foreach (var t in mainpanel.Children)
                {
                    if (t.Title == "资产转移")
                    {
                        t.IsActive = true;
                        break;
                    }
                }
            }
            else
            {
                Effective newEffective = new Effective();
                LayoutDocument newreport = new LayoutDocument();
                newreport.Title = "资产转移";
                newreport.IsActive = true;
                newreport.Content = newEffective;
                newEffective.Name = "newEffective";
                mainpanel.Children.Add(newreport);
            }

        }
    }
}
