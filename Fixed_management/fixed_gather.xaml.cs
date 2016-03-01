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
    /// fixed_gather.xaml 的交互逻辑
    /// </summary>
    public partial class fixed_gather : UserControl
    {
        public fixed_gather()
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
            Fixed_management.FixedDataSetTableAdapters.fixed_gatherTableAdapter fixed_gatherTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixed_gatherTableAdapter();
            fixed_gatherTableAdapter.Fill(fixedDataSet.fixed_gather);
            System.Windows.Data.CollectionViewSource fixed_gatherViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("fixed_gatherViewSource")));

            fixed_gatherDataGrid.CanUserAddRows = false;
        }

        private void gather_select_Click(object sender, RoutedEventArgs e)
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            if (textBox1.Text != "")
            {
                var s = from c in fixedDataSet.fixed_gather where c.category == textBox1.Text || c.fixed_status == textBox1.Text || c.fixed_vale == textBox1.Text || c.nature == textBox1.Text select c;
                fixed_gatherDataGrid.ItemsSource = s;
            }
            else
            {
                var s = from c in fixedDataSet.fixed_gather select c;
                fixed_gatherDataGrid.ItemsSource = s;
            }
        }
    }
}
