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
    /// fixed_detal.xaml 的交互逻辑
    /// </summary>
    public partial class fixed_detal : UserControl
    {
        public fixed_detal()
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
            Fixed_management.FixedDataSetTableAdapters.fixed_detalTableAdapter fixed_detalTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixed_detalTableAdapter();
            fixed_detalTableAdapter.Fill(fixedDataSet.fixed_detal);
            System.Windows.Data.CollectionViewSource fixed_detalViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("fixed_detalViewSource")));

            fixed_detalDataGrid.CanUserAddRows = false;
        }

        private void select_detal_Click(object sender, RoutedEventArgs e)
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            if (textBox1.Text != "")
            {
                var s = from c in fixedDataSet.fixed_detal where c.category == textBox1.Text || c.designation == textBox1.Text || c.fixed_number == int.Parse(textBox1.Text) || c.fixed_status == textBox1.Text || c.fixed_vale == textBox1.Text || c.nature == textBox1.Text || c.specifications == textBox1.Text select c;
                fixed_detalDataGrid.ItemsSource = s;
            }
            else 
            {
                var s = from c in fixedDataSet.fixed_detal select c;
                fixed_detalDataGrid.ItemsSource = s;
            }
        }
    }
}
