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
            Fixed_management.FixedDataSetTableAdapters.natureTableAdapter fixedDataSetnatureTableAdapter = new Fixed_management.FixedDataSetTableAdapters.natureTableAdapter();
            fixedDataSetnatureTableAdapter.Fill(fixedDataSet.nature);
            System.Windows.Data.CollectionViewSource natureViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("natureViewSource")));
            natureViewSource.View.MoveCurrentToFirst();

            Fixed_management.FixedDataSetTableAdapters.categoryTableAdapter fixedDataSetcategoryTableAdapter = new Fixed_management.FixedDataSetTableAdapters.categoryTableAdapter();
            fixedDataSetcategoryTableAdapter.Fill(fixedDataSet.category);
            System.Windows.Data.CollectionViewSource categoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));
            categoryViewSource.View.MoveCurrentToLast();
        }


        private void checkmultitable()
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 nature 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.natureTableAdapter fixedDataSetnatureTableAdapter = new Fixed_management.FixedDataSetTableAdapters.natureTableAdapter();
            System.Windows.Data.CollectionViewSource natureViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("natureViewSource")));

            Fixed_management.FixedDataSetTableAdapters.categoryTableAdapter fixedDataSetcategoryTableAdapter = new Fixed_management.FixedDataSetTableAdapters.categoryTableAdapter();
            System.Windows.Data.CollectionViewSource categoryViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("categoryViewSource")));

            Fixed_management.FixedDataSetTableAdapters.designationTableAdapter fixedDataSetdesignationTableAdapter = new Fixed_management.FixedDataSetTableAdapters.designationTableAdapter();
            System.Windows.Data.CollectionViewSource designationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("designationViewSource")));
            var nature = (from c in fixedDataSet.nature where c.nature == natureC1ComboBox.Text select c).Count();
            var category = (from c in fixedDataSet.category where c.category == categoryC1ComboBox.Text select c).Count();
            var designation = (from c in fixedDataSet.designation where c.designation == designationC1ComboBox.Text select c).Count();
            if (nature == 0)
            {
                fixedDataSet.nature.AddnatureRow(natureC1ComboBox.Text);
                fixedDataSetnatureTableAdapter.Update(fixedDataSet.nature);
                natureViewSource.View.MoveCurrentToLast();
            }
            if (category == 0)
            {
                fixedDataSet.category.AddcategoryRow(categoryC1ComboBox.Text);
                fixedDataSetcategoryTableAdapter.Update(fixedDataSet.category);
                categoryViewSource.View.MoveCurrentToLast();
            }
            if (designation == 0)
            {
                fixedDataSet.designation.AdddesignationRow(designationC1ComboBox.Text);
                fixedDataSetdesignationTableAdapter.Update(fixedDataSet.designation);
                designationViewSource.View.MoveCurrentToLast();
            }
        }

        private bool checknull()
        {
            bool check_status = true;
            string status_err="";
            if (natureC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "资产性质 ";
            }

            if (categoryC1ComboBox.Text==null)
            {
                check_status = false;
                status_err += "资产类别 ";
            }
            if (designationC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "资产名称 ";
            }


           
           // MessageBox.Show(status_err + "不能为空！");
            return check_status;
        }

        private void fixed_add_Click(object sender, RoutedEventArgs e)
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter fixedDataSetfixedTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter();
            if (checknull())
            {
                checkmultitable();

            }

        }

    }
}
