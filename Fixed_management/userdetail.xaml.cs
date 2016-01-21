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
    /// userdetail.xaml 的交互逻辑
    /// </summary>
    public partial class userdetail : UserControl
    {
        public userdetail()
        {
            InitializeComponent();
        }

        public int u_id;
        string[] per_list;
        string permsis;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // 不要在设计时加载数据。
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//在此处加载数据并将结果指派给 CollectionViewSource。
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }

            int i = u_id;
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 nature 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter fixedDataSetemployeesTableAdapter = new Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter();
            fixedDataSetemployeesTableAdapter.Fill(fixedDataSet.employees);

            if (u_id > 0)
            {

                numberTextBox.Text = fixedDataSet.employees.FindByemployees_ID(u_id).number.ToString();
                em_nameTextBox.Text = fixedDataSet.employees.FindByemployees_ID(u_id).em_name;
                passwordTextBox.Text = fixedDataSet.employees.FindByemployees_ID(u_id).password;

                if (fixedDataSet.employees.FindByemployees_ID(u_id).sex == "男")
                    {
                        radioButton1.IsChecked = true;
                    }
                    else
                    {
                        radioButton2.IsChecked = true;
                    }
                    phoneTextBox.Text = fixedDataSet.employees.FindByemployees_ID(u_id).phone;
                    addressTextBox.Text = fixedDataSet.employees.FindByemployees_ID(u_id).address;
                    contentTextBox.Text = fixedDataSet.employees.FindByemployees_ID(u_id).content;
                    load_check();
                
            }

        }
        private void load_check()
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 nature 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter fixedDataSetemployeesTableAdapter = new Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter();
            fixedDataSetemployeesTableAdapter.Fill(fixedDataSet.employees);
            string em_p = fixedDataSet.employees.FindByemployees_ID(u_id).pemissions;
            per_list = em_p.Split('f');
            foreach (string s in per_list)
            {
                if (s == "3")
                {
                    radioButton3.IsChecked = true;
                }
                if (s == "4")
                {
                    radioButton4.IsChecked = true;
                }
                if (s == "5")
                {
                    radioButton5.IsChecked = true;
                }
                if (s == "6")
                {
                    radioButton6.IsChecked = true;
                }
                if (s == "7")
                {
                    radioButton7.IsChecked = true;
                }
                if (s == "8")
                {
                    radioButton8.IsChecked = true;
                }
                if (s == "9")
                {
                    radioButton9.IsChecked = true;
                }
                if (s == "10")
                {
                    radioButton10.IsChecked = true;
                }
                if (s == "11")
                {
                    radioButton11.IsChecked = true;
                }
                if (s == "12")
                {
                    radioButton12.IsChecked = true;
                }
                if (s == "13")
                {
                    radioButton13.IsChecked = true;
                }
                if (s == "14")
                {
                    radioButton14.IsChecked = true;
                }
                if (s == "15")
                {
                    radioButton15.IsChecked = true;
                }
                if (s == "16")
                {
                    radioButton16.IsChecked = true;
                }
                if (s == "17")
                {
                    radioButton17.IsChecked = true;
                }
                if (s == "18")
                {
                    radioButton18.IsChecked = true;
                }
                if (s == "19")
                {
                    radioButton19.IsChecked = true;
                }
                if (s == "20")
                {
                    radioButton20.IsChecked = true;
                }
                if (s == "21")
                {
                    radioButton21.IsChecked = true;
                }
            }
          
        }

        private void ischeck()
        {
            string p;
           
            if ((bool)radioButton3.IsChecked)
            {
                p = "3f";
                permsis += p;
            }
            if ((bool)radioButton4.IsChecked)
            {
                p = "4f";
                permsis += p;
            }
            if ((bool)radioButton5.IsChecked)
            {
                p = "5f";
                permsis += p;
            }
            if ((bool)radioButton6.IsChecked)
            {
                p = "6f";
                permsis += p;
            }
            if ((bool)radioButton7.IsChecked)
            {
                p = "7f";
                permsis += p;
            }
            if ((bool)radioButton8.IsChecked)
            {
                p = "8f";
                permsis += p;
            }
            if ((bool)radioButton9.IsChecked)
            {
                p = "9f";
                permsis += p;
            }
            if ((bool)radioButton10.IsChecked)
            {
                p = "10f";
                permsis += p;
            }
            if ((bool)radioButton11.IsChecked)
            {
                p = "11f";
                permsis += p;
            }
            if ((bool)radioButton12.IsChecked)
            {
                p = "12f";
                permsis += p;
            }
            if ((bool)radioButton13.IsChecked)
            {
                p = "13f";
                permsis += p;
            }
            if ((bool)radioButton14.IsChecked)
            {
                p = "14f";
                permsis += p;
            }
            if ((bool)radioButton15.IsChecked)
            {
                p = "15f";
                permsis += p;
            }
            if ((bool)radioButton16.IsChecked)
            {
                p = "16f";
                permsis += p;
            }
            if ((bool)radioButton17.IsChecked)
            {
                p = "17f";
                permsis += p;
            }
            if ((bool)radioButton18.IsChecked)
            {
                p = "18f";
                permsis += p;
            }
            if ((bool)radioButton19.IsChecked)
            {
                p = "19f";
                permsis += p;
            }
            if ((bool)radioButton20.IsChecked)
            {
                p = "20f";
                permsis += p;
            }
            if ((bool)radioButton21.IsChecked)
            {
                p = "21f";
                permsis += p;
            }
            //per_list = permsis.Split('f');
           
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {

            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 nature 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter fixedDataSetemployeesTableAdapter = new Fixed_management.FixedDataSetTableAdapters.employeesTableAdapter();
            fixedDataSetemployeesTableAdapter.Fill(fixedDataSet.employees);
            System.Windows.Data.CollectionViewSource employeesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeesViewSource")));
            //employeesViewSource.View.MoveCurrentToFirst();





            ischeck();

            if (u_id < 1)
            {
                string sex = "";
                if ((bool)radioButton1.IsChecked)
                {
                    sex = "男";
                }
                else
                {
                    sex = "女";
                }
                fixedDataSet.employees.AddemployeesRow(numberTextBox.Text, em_nameTextBox.Text, passwordTextBox.Text, sex, DateTime.Now, "123456789", phoneTextBox.Text, addressTextBox.Text, contentTextBox.Text,permsis);
                fixedDataSetemployeesTableAdapter.Update(fixedDataSet.employees);
                fixedDataSet.AcceptChanges();
               
            }
            else
            {
                //employeesViewSource.View.MoveCurrentToNext();
                //fixedDataSetemployeesTableAdapter.Update(fixedDataSet.employees);
                var q = from c in fixedDataSet.employees where c.employees_ID == u_id select c;
                foreach (var t in q)
                {
                    t.number = numberTextBox.Text;
                    t.em_name = em_nameTextBox.Text;
                    t.password = passwordTextBox.Text;
                    if ((bool)radioButton1.IsChecked)
                    {
                        t.sex = "男";
                    }
                    else
                    {
                        t.sex = "女";
                    }
                    t.phone = phoneTextBox.Text;
                    t.address = addressTextBox.Text;
                    t.content = contentTextBox.Text;
                    t.pemissions = permsis;
                }
                fixedDataSetemployeesTableAdapter.Update(fixedDataSet.employees);
                

            }
            C1.WPF.C1Window findfixed = MainWindow.FindChild<C1.WPF.C1Window>(Application.Current.MainWindow, "employeeswindow");
            if (findfixed != null)
            {
                findfixed.Close();
            }



        }

        private void check_all_Click(object sender, RoutedEventArgs e)
        {
            radioButton3.IsChecked = true;
            radioButton4.IsChecked = true;
            radioButton5.IsChecked = true;
            radioButton6.IsChecked = true;
            radioButton7.IsChecked = true;
            radioButton8.IsChecked = true;
            radioButton9.IsChecked = true;
            radioButton10.IsChecked = true;
            radioButton11.IsChecked = true;
            radioButton12.IsChecked = true;
            radioButton13.IsChecked = true;
            radioButton14.IsChecked = true;
            radioButton15.IsChecked = true;
            radioButton16.IsChecked = true;
            radioButton17.IsChecked = true;
            radioButton18.IsChecked = true;
            radioButton19.IsChecked = true;
            radioButton20.IsChecked = true;
            radioButton21.IsChecked = true;
        }
    }
}
