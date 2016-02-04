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
using System.Collections;
using System.Collections.ObjectModel;

namespace Fixed_management
{
    /// <summary>
    /// Check.xaml 的交互逻辑
    /// </summary>
    public partial class Check : UserControl
    {
        public class check_item
        {
            public string barcode { get; set; }
            public string status { get; set; }
            public int fixed_id { get; set; }
            public string fixed_encoding { get; set; }
            public string designation { get; set; }
            public string category { get; set; }
            public string specifications { get; set; }
            public string model { get; set; }
            public string unit { get; set; }
            public string department { get; set; }
            public string keeper { get; set; }
            public string storage_place { get; set; }
        }

        public ArrayList check_all = new ArrayList();



        public Check()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            check_item null_item = new check_item();
            null_item.barcode = "";
            null_item.status = "";
            null_item.fixed_id = 0;
            null_item.fixed_encoding = "";
            null_item.designation = "";
            null_item.category = "";
            null_item.specifications = "";
            null_item.model = "";
            null_item.unit = "";
            null_item.department = "";
            null_item.keeper = "";
            null_item.storage_place = "";
            check_all.Add(null_item);

       
            // 不要在设计时加载数据。
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//在此处加载数据并将结果指派给 CollectionViewSource。
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void check_showDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {





        }


    }
}
