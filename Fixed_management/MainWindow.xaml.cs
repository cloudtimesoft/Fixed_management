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
using Xceed.Wpf.AvalonDock;

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
            newtextblock.Text = "当前登录  ：" + user;
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
                    if (t.Title == "有效资产")
                    {
                        t.IsActive = true;
                        break;
                    }
                }
            }
            else
            {
                Effective newEffective = new Effective();
                //newEffective.Margin = new Thickness(0, 20, 0, 0);
                LayoutDocument newreport = new LayoutDocument();
                newreport.Title = "有效资产";
                newreport.IsActive = true;
                newreport.Content = newEffective;
                newEffective.Name = "newEffective";
                mainpanel.Children.Add(newreport);
            }

        }

        private void transfer_information_Click(object sender, RoutedEventArgs e)
        {
            Transfer_info findfix = MainWindow.FindChild<Transfer_info>(Application.Current.MainWindow, "transferinfo");
            if (findfix != null)
            {
                foreach (var t in mainpanel.Children)
                {
                    if (t.Title == "转移信息")
                    {
                        t.IsActive = true;
                        break;
                    }
                }
            }
            else
            {
                Transfer_info transferinfo = new Transfer_info();
                LayoutDocument newreport = new LayoutDocument();
                newreport.Title = "转移信息";
                newreport.IsActive = true;
                newreport.Content = transferinfo;
                transferinfo.Name = "newEffective";
                mainpanel.Children.Add(newreport);
            }
        }


        private void fix_outtool_Click(object sender, RoutedEventArgs e)
        {
            Exit_assets findfix = MainWindow.FindChild<Exit_assets>(Application.Current.MainWindow, "Exit_assets");
            if (findfix != null)
            {
                foreach (var t in mainpanel.Children)
                {
                    if (t.Title == "资产退出")
                    {
                        t.IsActive = true;
                        break;
                    }
                }
            }
            else
            {
                Exit_assets exit_assets = new Exit_assets();
                LayoutDocument newreport = new LayoutDocument();
                newreport.Title = "资产退出";
                newreport.IsActive = true;
                newreport.Content = exit_assets;
                exit_assets.Name = "Exit_assets";
                mainpanel.Children.Add(newreport);
            }
        }

        private void exit_fixtool_Click(object sender, RoutedEventArgs e)
        {
            Exit_query findfix = MainWindow.FindChild<Exit_query>(Application.Current.MainWindow, "Exit_query");
            if (findfix != null)
            {
                foreach (var t in mainpanel.Children)
                {
                    if (t.Title == "退出资产")
                    {
                        t.IsActive = true;
                        break;
                    }
                }
            }
            else
            {
                Exit_query exit_query = new Exit_query();
                LayoutDocument newreport = new LayoutDocument();
                newreport.Title = "退出资产";
                newreport.IsActive = true;
                newreport.Content = exit_query;
                exit_query.Name = "Exit_query";
                mainpanel.Children.Add(newreport);
            }
        }

        private void fix_deltool_Click(object sender, RoutedEventArgs e)
        {
            Delete_assets findfix = MainWindow.FindChild<Delete_assets>(Application.Current.MainWindow, "Delete_assets");
            if (findfix != null)
            {
                foreach (var t in mainpanel.Children)
                {
                    if (t.Title == "资产删除")
                    {
                        t.IsActive = true;
                        break;
                    }
                }
            }
            else
            {
                Delete_assets delete_assets = new Delete_assets();
                LayoutDocument newreport = new LayoutDocument();
                newreport.Title = "资产删除";
                newreport.IsActive = true;
                newreport.Content = delete_assets;
                delete_assets.Name = "Delete_assets";
                mainpanel.Children.Add(newreport);
            }
        }

        private void del_fixtool_Click(object sender, RoutedEventArgs e)
        {
            Delete_query findfix = MainWindow.FindChild<Delete_query>(Application.Current.MainWindow, "Delete_query");
            if (findfix != null)
            {
                foreach (var t in mainpanel.Children)
                {
                    if (t.Title == "删除资产")
                    {
                        t.IsActive = true;
                        break;
                    }
                }
            }
            else
            {
                Delete_query Delete_query = new Delete_query();
                LayoutDocument newreport = new LayoutDocument();
                newreport.Title = "删除资产";
                newreport.IsActive = true;
                newreport.Content = Delete_query;
                Delete_query.Name = "Delete_query";
                mainpanel.Children.Add(newreport);
            }
        }

        private void Toolbar_loaded(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            if(overflowGrid != null)
            {
                overflowGrid.Visibility = Visibility.Collapsed;
            }
     
            var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            if(mainPanelBorder != null)
            {
                mainPanelBorder.Margin = new Thickness(0);
            }
        }

        private void shutdown_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void fix_inventorytool_Click(object sender, RoutedEventArgs e)
        {
            Check findfix = MainWindow.FindChild<Check>(Application.Current.MainWindow, "Check");
            if (findfix != null)
            {
                foreach (var t in mainpanel.Children)
                {
                    if (t.Title == "资产盘点")
                    {
                        t.IsActive = true;
                        break;
                    }
                }
            }
            else
            {
                Check check = new Check();
                LayoutDocument newreport = new LayoutDocument();
                newreport.Title = "资产盘点";
                newreport.IsActive = true;
                newreport.Content = check;
                check.Name = "Check";
                mainpanel.Children.Add(newreport);
            }
        }

        private void fixclass_detailtool_Click(object sender, RoutedEventArgs e)
        {
            fixed_detal findfix = MainWindow.FindChild<fixed_detal>(Application.Current.MainWindow, "fixed_detal");
            if (findfix != null)
            {
                foreach (var t in mainpanel.Children)
                {
                    if (t.Title == "资产分类明细表")
                    {
                        t.IsActive = true;
                        break;
                    }
                }
            }
            else
            {
                fixed_detal fixed_detal = new fixed_detal();
                LayoutDocument newreport = new LayoutDocument();
                newreport.Title = "资产分类明细表";
                newreport.IsActive = true;
                newreport.Content = fixed_detal;
                fixed_detal.Name = "fixed_detal";
                mainpanel.Children.Add(newreport);
            }
        }

        private void fixclass_tal_Click(object sender, RoutedEventArgs e)
        {
            fixed_gather findfix = MainWindow.FindChild<fixed_gather>(Application.Current.MainWindow, "fixed_gather");
            if (findfix != null)
            {
                foreach (var t in mainpanel.Children)
                {
                    if (t.Title == "资产分类汇总表")
                    {
                        t.IsActive = true;
                        break;
                    }
                }
            }
            else
            {
                fixed_gather fixed_gather = new fixed_gather();
                LayoutDocument newreport = new LayoutDocument();
                newreport.Title = "资产分类汇总表";
                newreport.IsActive = true;
                newreport.Content = fixed_gather;
                fixed_gather.Name = "fixed_gather";
                mainpanel.Children.Add(newreport);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

            Login login = new Login();
            login.Show();
            this.Close();

        }

        private void fix_prin_Click(object sender, RoutedEventArgs e)
        {


            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                var tbl = dockingManager;
                var size = new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);
                tbl.Measure(size);
                tbl.Arrange(new Rect(new Point(0, 0), size));
                
                printDialog.PrintVisual(tbl, "Print Test");
            }
        }

        private void fixed_about_Click(object sender, RoutedEventArgs e)
        {
            C1.WPF.C1Window findfixed = MainWindow.FindChild<C1.WPF.C1Window>(Application.Current.MainWindow, "about");
            if (findfixed != null)
            {
                findfixed.IsActive = true;
            }
            else
            {
                C1.WPF.C1Window newc1window = new C1.WPF.C1Window();
                newc1window.Name = "about";
                newc1window.IsResizable = false;
                newc1window.ShowMaximizeButton = false;
                newc1window.ShowMinimizeButton = false;
                newc1window.Width = 500;
                newc1window.Height = 400;
                newc1window.Margin = new Thickness(SystemParameters.PrimaryScreenWidth / 2d - 250, SystemParameters.PrimaryScreenHeight / 2d - 250, 0, 0);
                newc1window.Show();

                About newabout = new About();
                newabout.Name = "newabout";
                newc1window.Content = newabout;
            }

        }

      


    }
}
