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
    /// Exit_query.xaml 的交互逻辑
    /// </summary>
    public partial class Exit_query : UserControl
    {
        public Exit_query()
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
            Fixed_management.FixedDataSetTableAdapters.fixed_exitTableAdapter fixed_exitTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixed_exitTableAdapter();
            fixed_exitTableAdapter.Fill(fixedDataSet.fixed_exit);
            System.Windows.Data.CollectionViewSource fixed_exitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("fixed_exitViewSource")));
            fixed_exitViewSource.View.MoveCurrentToFirst();
        }
    }
}
