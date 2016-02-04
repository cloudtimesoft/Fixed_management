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
    /// Delete_query.xaml 的交互逻辑
    /// </summary>
    public partial class Delete_query : UserControl
    {
        public Delete_query()
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
            Fixed_management.FixedDataSetTableAdapters.fixed_del_queryTableAdapter fixed_del_queryTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixed_del_queryTableAdapter();
            fixed_del_queryTableAdapter.Fill(fixedDataSet.fixed_del_query);

            fixed_del_queryDataGrid.CanUserAddRows = false;


        }

        private void delete_fixed_Click(object sender, RoutedEventArgs e)
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 nature 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.fixed_del_queryTableAdapter fixed_del_queryTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixed_del_queryTableAdapter();
            //fixed_del_queryTableAdapter.Fill(fixedDataSet.fixed_del_query);

            Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter fixedTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter();
            fixedTableAdapter.Fill(fixedDataSet._fixed);


            for (int i = 0; i < fixed_del_queryDataGrid.Items.Count; i++)
            { 
                DataGridTemplateColumn templeColumn = fixed_del_queryDataGrid.Columns[0] as DataGridTemplateColumn;
                FrameworkElement s = fixed_del_queryDataGrid.Columns[0].GetCellContent(fixed_del_queryDataGrid.Items[i]);
                CheckBox tbOper = templeColumn.CellTemplate.FindName("checkbox", s) as CheckBox;
                DataRowView mySelectedElement = (DataRowView)fixed_del_queryDataGrid.Items[i];
                int fixed_del_id = int.Parse(mySelectedElement.Row[32].ToString());
                if ((bool)tbOper.IsChecked)
                {
                    fixedDataSet._fixed.FindByfixed_ID(fixed_del_id).Delete();
                }
                fixedTableAdapter.Update(fixedDataSet._fixed);
                fixedDataSet._fixed.AcceptChanges();

            }
            fixedDataSet.fixed_del_query.AcceptChanges();
            fixed_del_queryTableAdapter.Fill(fixedDataSet.fixed_del_query);
        }   

        private void clear_del_fixed_Click(object sender, RoutedEventArgs e)
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 nature 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.fixed_del_queryTableAdapter fixed_del_queryTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixed_del_queryTableAdapter();
            //fixed_del_queryTableAdapter.Fill(fixedDataSet.fixed_del_query);

            Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter fixedTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter();
            fixedTableAdapter.Fill(fixedDataSet._fixed);

            for (int i = 0; i < fixed_del_queryDataGrid.Items.Count; i++)
            {
                DataGridTemplateColumn templeColumn = fixed_del_queryDataGrid.Columns[0] as DataGridTemplateColumn;
                FrameworkElement s = fixed_del_queryDataGrid.Columns[0].GetCellContent(fixed_del_queryDataGrid.Items[i]);
                DataRowView mySelectedElement = (DataRowView)fixed_del_queryDataGrid.Items[i];
                int fixed_del_id = int.Parse(mySelectedElement.Row[32].ToString());

                fixedDataSet._fixed.FindByfixed_ID(fixed_del_id).Delete();
                fixedTableAdapter.Update(fixedDataSet._fixed);
                fixedDataSet._fixed.AcceptChanges();

            }
            fixedDataSet.fixed_del_query.AcceptChanges();
            fixed_del_queryTableAdapter.Fill(fixedDataSet.fixed_del_query);
        }

        private void restore_del_fixed_Click(object sender, RoutedEventArgs e)
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 nature 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.fixed_del_queryTableAdapter fixed_del_queryTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixed_del_queryTableAdapter();
            //fixed_del_queryTableAdapter.Fill(fixedDataSet.fixed_del_query);

            Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter fixedTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter();
            fixedTableAdapter.Fill(fixedDataSet._fixed);

            for (int i = 0; i < fixed_del_queryDataGrid.Items.Count; i++)
            {
                DataGridTemplateColumn templeColumn = fixed_del_queryDataGrid.Columns[0] as DataGridTemplateColumn;
                FrameworkElement s = fixed_del_queryDataGrid.Columns[0].GetCellContent(fixed_del_queryDataGrid.Items[i]);
                CheckBox tbOper = templeColumn.CellTemplate.FindName("checkbox", s) as CheckBox;
                DataRowView mySelectedElement = (DataRowView)fixed_del_queryDataGrid.Items[i];
                int fixed_del_id = int.Parse(mySelectedElement.Row[32].ToString());
                if ((bool)tbOper.IsChecked)
                {
                    var Vdel_status = from c in fixedDataSet._fixed where c.fixed_ID == fixed_del_id select c;
                    foreach (var a in Vdel_status)
                    {
                        a.del_status = "1";
                    }
                }
            }
            fixedTableAdapter.Update(fixedDataSet._fixed);
            fixedDataSet._fixed.AcceptChanges();
            fixedTableAdapter.Fill(fixedDataSet._fixed);

            fixedDataSet.fixed_del_query.AcceptChanges();
            fixed_del_queryTableAdapter.Fill(fixedDataSet.fixed_del_query);
        }
    }
}
