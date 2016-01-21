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
    /// employees.xaml 的交互逻辑
    /// </summary>
    public partial class employees : UserControl
    {
        public employees()
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
            System.Windows.Data.CollectionViewSource employeesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeesViewSource")));
            employeesViewSource.View.MoveCurrentToFirst();
            employeesDataGrid.CanUserAddRows = false;
        }

        private void add_employess_Click(object sender, RoutedEventArgs e)
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter fixedDataSetemoyeesTableAdapter = new Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter();
            if (checknull())
            {
                if (passwordTextBox.Text == confirm_passwordTextBox.Text)
                {
                    if (sexTextBox.Text == "")
                    {
                        sexTextBox.Text = "";
                    }
                    if (birthdayDatePicker.Text == "")
                    {
                        birthdayDatePicker.SelectedDate = DateTime.Now;
                    }
                    if (id_numberTextBox.Text == "")
                    {
                        id_numberTextBox.Text = "";
                    }
                    if (phoneTextBox.Text == "")
                    {
                        phoneTextBox.Text = "";
                    }
                    if (addressTextBox.Text == "")
                    {
                        addressTextBox.Text = "";
                    }
                    if (contentTextBox.Text == "")
                    {
                        contentTextBox.Text = "";
                    }
                    fixedDataSet.employees.AddemployeesRow(numberTextBox.Text, em_nameTextBox.Text, passwordTextBox.Text,sexTextBox.Text, DateTime.Parse(birthdayDatePicker.Text), id_numberTextBox.Text, phoneTextBox.Text, addressTextBox.Text, contentTextBox.Text,"");
                    fixedDataSetemoyeesTableAdapter.Update(fixedDataSet.employees);
                    fixedDataSet.employees.AcceptChanges();
                    fixedDataSetemoyeesTableAdapter.Fill(fixedDataSet.employees);
                }
                else
                {
                    MessageBox.Show("密码不一致！");
                }

            }
          
        }
        private bool checknull()
        {
            bool check_status = true;
            string status_err = "";
            if (numberTextBox.Text == "")
            {
                check_status = false;
                status_err += "员工编号 ";
            }

            if (em_nameTextBox.Text == "")
            {
                check_status = false;
                status_err += "员工姓名 ";
            }
            if (passwordTextBox.Text == "")
            {
                check_status = false;
                status_err += "密码 ";
            }
            if (confirm_passwordTextBox.Text == "")
            {
                check_status = false;
                status_err += "确认密码 ";
            }

            if (!check_status)
            {
                MessageBox.Show(status_err + "不能为空！");
            }
        
            return check_status;
          
        }

    }
}
