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

        }

        private void add_user_Click(object sender, RoutedEventArgs e)
        {
            C1.WPF.C1Window employeeswindow = new C1.WPF.C1Window();
            employeeswindow.IsResizable = false;
            employeeswindow.Name = "employeeswindow";
            employeeswindow.Width = 700;
            employeeswindow.Height = 550;
            employeeswindow.Header = "员工管理";
            employeeswindow.Margin = new Thickness(SystemParameters.PrimaryScreenWidth / 2d - 250, SystemParameters.PrimaryScreenHeight / 2d - 250, 0, 0);
            employeeswindow.ShowModal();
            employeeswindow.ShowMaximizeButton = false;
            employeeswindow.ShowMinimizeButton = false;
            userdetail newemployees = new userdetail();
            newemployees.Name = "newemployees";
            employeeswindow.Content = newemployees;
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            C1.WPF.C1Window employeeswindow = new C1.WPF.C1Window();
            employeeswindow.IsResizable = false;
            employeeswindow.Name = "employeeswindow";
            employeeswindow.Width = 700;
            employeeswindow.Height = 550;
            employeeswindow.Header = "员工管理";
            employeeswindow.Margin = new Thickness(SystemParameters.PrimaryScreenWidth / 2d - 250, SystemParameters.PrimaryScreenHeight / 2d - 250, 0, 0);
            employeeswindow.Show();
            employeeswindow.ShowMaximizeButton = false;
            employeeswindow.ShowMinimizeButton = false;
            userdetail newemployees = new userdetail();
            newemployees.Name = "newemployees";
            var t = employeesDataGrid.SelectedItem;
            var b = t as DataRowView;
            int s = int.Parse(b.Row[0].ToString());
            //Public.user_id = s;
            newemployees.u_id = s;
            employeeswindow.Content = newemployees;
        }
    }
}
