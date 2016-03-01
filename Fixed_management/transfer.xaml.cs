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
using System.Threading;

namespace Fixed_management
{
    /// <summary>
    /// transfer.xaml 的交互逻辑
    /// </summary>
    public partial class transfer : UserControl
    {
        public transfer()
        {
            InitializeComponent();
        }
        string barcode;
        string old_affiliated;
        string old_department;
        string old_keeper;
        string old_storage_place;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            fixednameDataGrid.CanUserAddRows = false;


            // 不要在设计时加载数据。
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//在此处加载数据并将结果指派给 CollectionViewSource。
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }

            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 nature 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter fixednameTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter();
            fixednameTableAdapter.Fill(fixedDataSet.fixedname);
            System.Windows.Data.CollectionViewSource fixednameViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("fixednameViewSource")));
            fixednameViewSource.View.MoveCurrentToFirst();

            Fixed_management.FixedDataSetTableAdapters.affiliatedTableAdapter fixedDataSetaffiliatedTableAdapter = new Fixed_management.FixedDataSetTableAdapters.affiliatedTableAdapter();
            fixedDataSetaffiliatedTableAdapter.Fill(fixedDataSet.affiliated);
            System.Windows.Data.CollectionViewSource affiliatedViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("affiliatedViewSource")));
            affiliatedViewSource.View.MoveCurrentToFirst();

            Fixed_management.FixedDataSetTableAdapters.departmentTableAdapter fixedDataSetdepartmentTableAdapter = new Fixed_management.FixedDataSetTableAdapters.departmentTableAdapter();
            fixedDataSetdepartmentTableAdapter.Fill(fixedDataSet.department);
            System.Windows.Data.CollectionViewSource departmentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("departmentViewSource")));
            departmentViewSource.View.MoveCurrentToFirst();

            Fixed_management.FixedDataSetTableAdapters.keeperTableAdapter fixedDataSetkeeperTableAdapter = new Fixed_management.FixedDataSetTableAdapters.keeperTableAdapter();
            fixedDataSetkeeperTableAdapter.Fill(fixedDataSet.keeper);
            System.Windows.Data.CollectionViewSource keeperViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("keeperViewSource")));
            keeperViewSource.View.MoveCurrentToFirst();

            Fixed_management.FixedDataSetTableAdapters.storage_placeTableAdapter fixedDataSetstorage_placeTableAdapter = new Fixed_management.FixedDataSetTableAdapters.storage_placeTableAdapter();
            fixedDataSetstorage_placeTableAdapter.Fill(fixedDataSet.storage_place);
            System.Windows.Data.CollectionViewSource storage_placeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("storage_placeViewSource")));
            storage_placeViewSource.View.MoveCurrentToFirst();

           transfer_dateDatePicker.SelectedDate = DateTime.Now;
           transfer_select.Margin = new Thickness(SystemParameters.PrimaryScreenWidth - 100, 70, 0, 0);
           textBox1.Margin = new Thickness(SystemParameters.PrimaryScreenWidth - 230, 70, 0, 0);
        }


        private bool check_repat(int i)
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter fixedTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter();
            fixedTableAdapter.Fill(fixedDataSet._fixed);


            var Vaffiliated = from c in fixedDataSet.affiliated where c.affiliated == affiliated_IDC1ComboBox.Text select c;
            int Iaffiliated = 0;
            foreach (var a in Vaffiliated)
            {
                Iaffiliated = a.affiliated_ID;
                break;
            }


            var Vdepartment = from c in fixedDataSet.department where c.department == department_IDC1ComboBox.Text select c;
            int Idepartment = 0;
            foreach (var a in Vdepartment)
            {
                Idepartment = a.department_ID;
                break;
            }

            var Vstorage_place = from c in fixedDataSet.storage_place where c.storage_place == storage_place_IDC1ComboBox.Text select c;
            int Istorage_place = 0;
            foreach (var a in Vstorage_place)
            {
                Istorage_place = a.storage_place_ID;
                break;
            }


            var Vkeeper = from c in fixedDataSet.keeper where c.keeper == keeper_IDC1ComboBox.Text select c;
            int Ikeeper = 0;
            foreach (var a in Vkeeper)
            {
                Ikeeper = a.keeper_ID;
                break;
            }

            int s = (from c in fixedDataSet._fixed where c.affiliated_ID == Iaffiliated && c.department_ID == Idepartment && c.keeper_ID == Ikeeper && c.storage_place_ID == Istorage_place && c.fixed_ID == i select c).Count();
            if (s > 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private void transfer_btn_Click(object sender, RoutedEventArgs e)
        {
            

            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter fixedTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixedTableAdapter();
            fixedTableAdapter.Fill(fixedDataSet._fixed);
          
            if (checknull())
            {
                checkmultitable();



                for (int i = 0; i < fixednameDataGrid.Items.Count; i++)
                {
                    DataGridTemplateColumn templeColumn = fixednameDataGrid.Columns[0] as DataGridTemplateColumn;
                    FrameworkElement s = fixednameDataGrid.Columns[0].GetCellContent(fixednameDataGrid.Items[i]);
                    CheckBox tbOper = templeColumn.CellTemplate.FindName("checkbox", s) as CheckBox;
                    DataRowView mySelectedElement = (DataRowView)fixednameDataGrid.Items[i];
                    int fixedname_id = int.Parse(mySelectedElement.Row[32].ToString());
                    if ((bool)tbOper.IsChecked && check_repat(fixedname_id))
                    {
                        

                        barcode = mySelectedElement.Row[0].ToString();
                        old_affiliated = mySelectedElement.Row[28].ToString();
                        old_department = mySelectedElement.Row[29].ToString();
                        old_keeper = mySelectedElement.Row[22].ToString();
                        old_storage_place = mySelectedElement.Row[31].ToString();


                        var Vaffiliated = from c in fixedDataSet.affiliated where c.affiliated == affiliated_IDC1ComboBox.Text select c;
                        int Iaffiliated = 0;
                        foreach (var a in Vaffiliated)
                        {
                            Iaffiliated = a.affiliated_ID;
                            break;
                        }

                        var Vdepartment = from c in fixedDataSet.department where c.department == department_IDC1ComboBox.Text select c;
                        int Idepartment = 0;
                        foreach (var a in Vdepartment)
                        {
                            Idepartment = a.department_ID;
                            break;
                        }

                        var Vstorage_place = from c in fixedDataSet.storage_place where c.storage_place == storage_place_IDC1ComboBox.Text select c;
                        int Istorage_place = 0;
                        foreach (var a in Vstorage_place)
                        {
                            Istorage_place = a.storage_place_ID;
                            break;
                        }


                        var Vkeeper = from c in fixedDataSet.keeper where c.keeper == keeper_IDC1ComboBox.Text select c;
                        int Ikeeper = 0;
                        foreach (var a in Vkeeper)
                        {
                            Ikeeper = a.keeper_ID;
                            break;
                        }



                        var t = from c in fixedDataSet._fixed where c.fixed_ID == fixedname_id select c;
                        foreach (var n in t)
                        {
                           
                            n.affiliated_ID = Iaffiliated;
                            n.department_ID = Idepartment;
                            n.keeper_ID = Ikeeper;
                            n.storage_place_ID = Istorage_place;
                        }
                        transfer_detail();
                    }
                    fixedTableAdapter.Update(fixedDataSet._fixed);
                    fixedDataSet._fixed.AcceptChanges();

                }
              

                Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter fixednameTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter();
                fixedDataSet.fixedname.AcceptChanges();
                fixednameTableAdapter.Fill(fixedDataSet.fixedname);

                //transfer_detail();

            }
              

        }

        private bool checknull()
        {
            bool check_status = true;
            string status_err = "";
          
            if (affiliated_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "所属单位 ";
            }
            if (department_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "保管部门 ";
            }
            if (keeper_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "保管人 ";
            }
          
            if (storage_place_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "存放地点 ";
            }



            if (!check_status)
            {
                MessageBox.Show(status_err + "不能为空！");
            }
            return check_status;

        }

        private void transfer_detail()
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            Fixed_management.FixedDataSetTableAdapters.transfer_detailTableAdapter transfer_detailTableAdapter = new Fixed_management.FixedDataSetTableAdapters.transfer_detailTableAdapter();
            

            //DateTime s = DateTime.Parse(transfer_dateDatePicker.Text);

            fixedDataSet.transfer_detail.Addtransfer_detailRow(DateTime.Parse(transfer_dateDatePicker.Text), barcode, old_affiliated, old_department, old_keeper, old_storage_place, affiliated_IDC1ComboBox.Text, department_IDC1ComboBox.Text, keeper_IDC1ComboBox.Text, storage_place_IDC1ComboBox.Text);
            transfer_detailTableAdapter.Update(fixedDataSet.transfer_detail);
            fixedDataSet.transfer_detail.AcceptChanges();
            transfer_detailTableAdapter.Fill(fixedDataSet.transfer_detail);

        }

        private void checkmultitable()
        {
          

            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            Fixed_management.FixedDataSetTableAdapters.affiliatedTableAdapter fixedDataSetaffiliatedTableAdapter = new Fixed_management.FixedDataSetTableAdapters.affiliatedTableAdapter();
            fixedDataSetaffiliatedTableAdapter.Fill(fixedDataSet.affiliated);
            System.Windows.Data.CollectionViewSource affiliatedViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("affiliatedViewSource")));
            affiliatedViewSource.View.MoveCurrentToLast();

            Fixed_management.FixedDataSetTableAdapters.departmentTableAdapter fixedDataSetdepartmentTableAdapter = new Fixed_management.FixedDataSetTableAdapters.departmentTableAdapter();
            fixedDataSetdepartmentTableAdapter.Fill(fixedDataSet.department);
            System.Windows.Data.CollectionViewSource departmentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("departmentViewSource")));
            departmentViewSource.View.MoveCurrentToLast();

            Fixed_management.FixedDataSetTableAdapters.keeperTableAdapter fixedDataSetkeeperTableAdapter = new Fixed_management.FixedDataSetTableAdapters.keeperTableAdapter();
            fixedDataSetkeeperTableAdapter.Fill(fixedDataSet.keeper);
            System.Windows.Data.CollectionViewSource keeperViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("keeperViewSource")));
            keeperViewSource.View.MoveCurrentToLast();

            Fixed_management.FixedDataSetTableAdapters.storage_placeTableAdapter fixedDataSetstorage_placeTableAdapter = new Fixed_management.FixedDataSetTableAdapters.storage_placeTableAdapter();
            fixedDataSetstorage_placeTableAdapter.Fill(fixedDataSet.storage_place);
            System.Windows.Data.CollectionViewSource storage_placeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("storage_placeViewSource")));
            storage_placeViewSource.View.MoveCurrentToLast();

           
            //Fixed_management.FixedDataSetTableAdapters.transfer_detailTableAdapter transfer_detailTableAdapter = new Fixed_management.FixedDataSetTableAdapters.transfer_detailTableAdapter();
            //transfer_detailTableAdapter.Fill(fixedDataSet.transfer_detail);
            //System.Windows.Data.CollectionViewSource transfer_detailViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("transfer_detailViewSource")));
            //transfer_detailViewSource.View.MoveCurrentToLast();



            var affiliated = (from c in fixedDataSet.affiliated where c.affiliated == affiliated_IDC1ComboBox.Text select c).Count();
            var department = (from c in fixedDataSet.department where c.department == department_IDC1ComboBox.Text select c).Count();
            var keeper = (from c in fixedDataSet.keeper where c.keeper == keeper_IDC1ComboBox.Text select c).Count();
            var storage_place = (from c in fixedDataSet.storage_place where c.storage_place == storage_place_IDC1ComboBox.Text select c).Count();

            if (affiliated == 0)
            {
                fixedDataSet.affiliated.AddaffiliatedRow(1, affiliated_IDC1ComboBox.Text);
                fixedDataSetaffiliatedTableAdapter.Update(fixedDataSet.affiliated);
                fixedDataSet.affiliated.AcceptChanges();
                fixedDataSetaffiliatedTableAdapter.Fill(fixedDataSet.affiliated);
                affiliatedViewSource.View.MoveCurrentToLast();
              
            }
            if (department == 0)
            {
                fixedDataSet.department.AdddepartmentRow(1, department_IDC1ComboBox.Text);
                fixedDataSetdepartmentTableAdapter.Update(fixedDataSet.department);
                fixedDataSet.department.AcceptChanges();
                fixedDataSetdepartmentTableAdapter.Fill(fixedDataSet.department);
                departmentViewSource.View.MoveCurrentToLast();
            }
            if (keeper == 0)
            {
                fixedDataSet.keeper.AddkeeperRow(keeper_IDC1ComboBox.Text);
                fixedDataSetkeeperTableAdapter.Update(fixedDataSet.keeper);
                fixedDataSet.keeper.AcceptChanges();
                fixedDataSetkeeperTableAdapter.Fill(fixedDataSet.keeper);
                keeperViewSource.View.MoveCurrentToLast();
            }

            if (storage_place == 0)
            {
                fixedDataSet.storage_place.Addstorage_placeRow(storage_place_IDC1ComboBox.Text);
                fixedDataSetstorage_placeTableAdapter.Update(fixedDataSet.storage_place);
                fixedDataSet.storage_place.AcceptChanges();
                fixedDataSetstorage_placeTableAdapter.Fill(fixedDataSet.storage_place);
                storage_placeViewSource.View.MoveCurrentToLast();
            }


           
        }

        private void transfer_select_Click(object sender, RoutedEventArgs e)
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 nature 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter fixednameTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter();
            //fixednameTableAdapter.Fill(fixedDataSet.fixedname);
            System.Windows.Data.CollectionViewSource fixednameViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("fixednameViewSource")));
            if (textBox1.Text != "")
            {
                var s = from c in fixedDataSet.fixedname where c.storage_place == textBox1.Text || c.barcode == textBox1.Text || c.limit == int.Parse(textBox1.Text) || c.fixed_number == int.Parse(textBox1.Text) || c.fixed_vale == textBox1.Text || c.factory_number == textBox1.Text || c.fixed_encoding == textBox1.Text || c.warranty == int.Parse(textBox1.Text) || c.account_number == textBox1.Text || c.fixed_asset == textBox1.Text || c.card_number == textBox1.Text || c.nature == textBox1.Text || c.category == textBox1.Text || c.specifications == textBox1.Text || c.designation == textBox1.Text || c.model == textBox1.Text || c.unit == textBox1.Text || c.purchase_way == textBox1.Text || c.keeper == textBox1.Text || c.supplier == textBox1.Text || c.position == textBox1.Text || c.fixed_status == textBox1.Text || c.user == textBox1.Text || c._operator == textBox1.Text || c.affiliated == textBox1.Text || c.department == textBox1.Text || c.content == textBox1.Text select c;
                fixednameDataGrid.ItemsSource = s;
            }
            else
            {
                var s = from c in fixedDataSet.fixedname select c;
                fixednameDataGrid.ItemsSource = s;
            }
        }

    }
}
