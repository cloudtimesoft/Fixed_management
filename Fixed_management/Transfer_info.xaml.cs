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
    /// Transfer_Fixed.xaml 的交互逻辑
    /// </summary>
    public partial class Transfer_info : UserControl
    {
        public Transfer_info()
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
            Fixed_management.FixedDataSetTableAdapters.transfer_detailTableAdapter transfer_detailTableAdapter = new Fixed_management.FixedDataSetTableAdapters.transfer_detailTableAdapter();
            transfer_detailTableAdapter.Fill(fixedDataSet.transfer_detail);
            System.Windows.Data.CollectionViewSource transfer_detailViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("transfer_detailViewSource")));
            transfer_detailViewSource.View.MoveCurrentToFirst();


            Fixed_management.FixedDataSetTableAdapters.affiliatedTableAdapter fixedDataSetaffiliatedTableAdapter = new Fixed_management.FixedDataSetTableAdapters.affiliatedTableAdapter();
            fixedDataSetaffiliatedTableAdapter.Fill(fixedDataSet.affiliated);
          

            Fixed_management.FixedDataSetTableAdapters.departmentTableAdapter fixedDataSetdepartmentTableAdapter = new Fixed_management.FixedDataSetTableAdapters.departmentTableAdapter();
            fixedDataSetdepartmentTableAdapter.Fill(fixedDataSet.department);
          

            Fixed_management.FixedDataSetTableAdapters.keeperTableAdapter fixedDataSetkeeperTableAdapter = new Fixed_management.FixedDataSetTableAdapters.keeperTableAdapter();
            fixedDataSetkeeperTableAdapter.Fill(fixedDataSet.keeper);
          

            Fixed_management.FixedDataSetTableAdapters.storage_placeTableAdapter fixedDataSetstorage_placeTableAdapter = new Fixed_management.FixedDataSetTableAdapters.storage_placeTableAdapter();
            fixedDataSetstorage_placeTableAdapter.Fill(fixedDataSet.storage_place);
           

            Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter fixedTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter();
            fixedTableAdapter.Fill(fixedDataSet._fixed);









            transfer_detailDataGrid.CanUserAddRows = false;
        }

        private void reductive_transfer_Click(object sender, RoutedEventArgs e)
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            Fixed_management.FixedDataSetTableAdapters.transfer_detailTableAdapter transfer_detailTableAdapter = new Fixed_management.FixedDataSetTableAdapters.transfer_detailTableAdapter();

            Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter fixedTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter();
            fixedTableAdapter.Fill(fixedDataSet._fixed);



            string affiliated= "";
            string department="";
            string keeper="";
            string storage_place="";
            string fixedname_bar = "";
           
            List<int> trn_id=new List<int>();
            for (int i = 0; i < transfer_detailDataGrid.Items.Count;i++)
            {
                DataGridTemplateColumn templeColumn = transfer_detailDataGrid.Columns[0] as DataGridTemplateColumn;
                FrameworkElement s = transfer_detailDataGrid.Columns[0].GetCellContent(transfer_detailDataGrid.Items[i]);
                CheckBox tbOper = templeColumn.CellTemplate.FindName("checkbox", s) as CheckBox;
                DataRowView mySelectedElement = (DataRowView)transfer_detailDataGrid.Items[i];
                 fixedname_bar = mySelectedElement.Row[2].ToString();
                if ((bool)tbOper.IsChecked)
                {
                    var v = from c in fixedDataSet.transfer_detail where c.barcode == fixedname_bar select c;
                    foreach (var t in v)
                    {
                        // bar=t.barcode;
                         affiliated = t.old_affiliated;
                         department = t.old_department;
                         keeper = t.old_keeper;
                         storage_place = t.old_storage_place;
                         trn_id.Add(t.transfer_detail_ID);
                        
                    }

                        var Vaffiliated = from c in fixedDataSet.affiliated where c.affiliated == affiliated select c;
                        int Iaffiliated = 0;
                        foreach (var a in Vaffiliated)
                        {
                            Iaffiliated = a.affiliated_ID;
                            break;
                        }

                        var Vdepartment = from c in fixedDataSet.department where c.department == department select c;
                        int Idepartment = 0;
                        foreach (var a in Vdepartment)
                        {
                            Idepartment = a.department_ID;
                            break;
                        }

                        var Vstorage_place = from c in fixedDataSet.storage_place where c.storage_place == storage_place select c;
                        int Istorage_place = 0;
                        foreach (var a in Vstorage_place)
                        {
                            Istorage_place = a.storage_place_ID;
                            break;
                        }


                        var Vkeeper = from c in fixedDataSet.keeper where c.keeper == keeper select c;
                        int Ikeeper = 0;
                        foreach (var a in Vkeeper)
                        {
                            Ikeeper = a.keeper_ID;
                            break;
                        }


                      var f = from c in fixedDataSet._fixed where c.barcode ==  fixedname_bar select c;

                    foreach (var id in f)
                    {
                        id.affiliated_ID = Iaffiliated;
                        id.department_ID = Idepartment;
                        id.storage_place_ID = Istorage_place;
                        id.keeper_ID = Ikeeper;
                    }
                   

                    fixedTableAdapter.Update(fixedDataSet._fixed);
                    fixedDataSet._fixed.AcceptChanges();
                    //fixedTableAdapter.Fill(fixedDataSet._fixed);

        
                }

              
            }

         


            Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter fixednameTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter();
            fixedDataSet.fixedname.AcceptChanges();
            fixednameTableAdapter.Fill(fixedDataSet.fixedname);


            foreach(int a in trn_id)
            {

                fixedDataSet.transfer_detail.FindBytransfer_detail_ID(a).Delete();
            }
            transfer_detailTableAdapter.Update(fixedDataSet.transfer_detail);
            fixedDataSet.transfer_detail.AcceptChanges();

        }
    }
}
