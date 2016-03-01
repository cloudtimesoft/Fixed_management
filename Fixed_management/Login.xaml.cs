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
using System.Windows.Shapes;

namespace Fixed_management
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            numberTextBox.Focus();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 employees 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter fixedDataSetemployeesTableAdapter = new Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter();
            fixedDataSetemployeesTableAdapter.Fill(fixedDataSet.employees);
            System.Windows.Data.CollectionViewSource employeesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeesViewSource")));
            employeesViewSource.View.MoveCurrentToFirst();

            int s = (from c in fixedDataSet.employees where c.number == numberTextBox.Text && c.password == passwordTextBox.Password select c).Count();
            var id = from c in fixedDataSet.employees where c.number == numberTextBox.Text && c.password == passwordTextBox.Password select c;
            //user_id
            foreach (var t in id)
            {
               Public.user_id = t.employees_ID;
            }
            if (s > 0)
            {
                MainWindow newmain = new MainWindow();
                Application.Current.MainWindow = newmain;
                this.Close();
                newmain.Show();
            }
            else
            {
                MessageBox.Show( "用户名或密码有误！","提示");
            }

        }

    

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Key Key = (e.Key == Key.System ? e.SystemKey : e.Key);
            //if (Key == Key.Enter)
            //{
            //    login_Click(null, null);
            //}
        }

        private void numberTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                passwordTextBox.Focus();
            }
        }

        private void passwordTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                login_Click(null, null);
            }
        }

    }
}
