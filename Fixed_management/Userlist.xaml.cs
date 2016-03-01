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
using System.Data;

namespace Fixed_management
{
    /// <summary>
    /// Userlist.xaml 的交互逻辑
    /// </summary>
    public partial class Userlist : UserControl
    {
        public Userlist()
        {
            InitializeComponent();

        }
        

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // 不要在设计时加载数据。
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//在此处加载数据并将结果指派给 CollectionViewSource。
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 nature 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter fixedDataSetemployeesTableAdapter = new Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter();
            fixedDataSetemployeesTableAdapter.Fill(fixedDataSet.employees);
            //System.Windows.Data.CollectionViewSource employeesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeesViewSource")));
            //employeesViewSource.View.MoveCurrentToFirst();
            employeesDataGrid.CanUserAddRows = false;

            
            var s = from c in fixedDataSet.employees select c;
            foreach (var i in s)
            {
                if (i.number == "001")
                {
                   
                }
            }
           


        }

        private void add_user_Click(object sender, RoutedEventArgs e)
        {
            C1.WPF.C1Window employeeswindow = new C1.WPF.C1Window();
            employeeswindow.IsResizable = false;
            employeeswindow.Name = "employeeswindow1";
            employeeswindow.Width = 700;
            employeeswindow.Height = 550;
            employeeswindow.Header = "员工管理";
            employeeswindow.Margin = new Thickness(SystemParameters.PrimaryScreenWidth / 2d - 250, SystemParameters.PrimaryScreenHeight / 2d - 250, 0, 0);
            employeeswindow.ShowModal();
            employeeswindow.ShowMaximizeButton = false;
            employeeswindow.ShowMinimizeButton = false;
            userdetail newemployees = new userdetail();
            newemployees.Name = "newemployees1";
            employeeswindow.Content = newemployees;

            //newemployees.C1Window += new RoutedPropertyChangedEventHandler<object>(newemployees_C1Window);
            //Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            //Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter fixedDataSetemployeesTableAdapter = new Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter();
            //fixedDataSet.employees.AcceptChanges();
            //fixedDataSetemployeesTableAdapter.Fill(fixedDataSet.employees);
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

            var t = employeesDataGrid.SelectedItem;
            var b = t as DataRowView;
            int s = int.Parse(b.Row[0].ToString());
            string edit_num = b.Row[1].ToString();

            if (edit_num == "admin")
            {
                MessageBox.Show("无法编辑管理员", "提示");
            }
            else
            {
                C1.WPF.C1Window employeeswindow = new C1.WPF.C1Window();
                employeeswindow.IsResizable = false;
                employeeswindow.Name = "employeeswindow2";
                employeeswindow.Width = 700;
                employeeswindow.Height = 550;
                employeeswindow.Header = "员工管理";
                employeeswindow.Margin = new Thickness(SystemParameters.PrimaryScreenWidth / 2d - 250, SystemParameters.PrimaryScreenHeight / 2d - 250, 0, 0);
                employeeswindow.Show();
                employeeswindow.ShowMaximizeButton = false;
                employeeswindow.ShowMinimizeButton = false;
                userdetail newemployees = new userdetail();
                newemployees.Name = "newemployees2";

                //Public.user_id = s;
                newemployees.u_id = s;
                employeeswindow.Content = newemployees;

            }
            

        }

        void newemployees_C1Window(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            var a = from c in fixedDataSet.employees select c;
            employeesDataGrid.ItemsSource = a;

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var t = employeesDataGrid.SelectedItem;
            var b = t as DataRowView;
            int s = int.Parse(b.Row[0].ToString());
            string num = b.Row[1].ToString();
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 nature 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter fixedDataSetemployeesTableAdapter = new Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter();

            if (num == "admin")
            {
                MessageBox.Show("无法删除管理员", "提示");
            }
            else
            {
                fixedDataSet.employees.FindByemployees_ID(s).Delete();
                fixedDataSetemployeesTableAdapter.Update(fixedDataSet.employees);
                fixedDataSetemployeesTableAdapter.Fill(fixedDataSet.employees);
                fixedDataSet.employees.AcceptChanges();
            }
        }
    }
}
