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

            Fixed_management.FixedDataSetTableAdapters.designationTableAdapter fixedDataSetdesignationTableAdapter = new Fixed_management.FixedDataSetTableAdapters.designationTableAdapter();
            fixedDataSetdesignationTableAdapter.Fill(fixedDataSet.designation);
            System.Windows.Data.CollectionViewSource designationViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("designationViewSource")));
            designationViewSource.View.MoveCurrentToLast();

            Fixed_management.FixedDataSetTableAdapters.specificationsTableAdapter fixedDataSetspecificationsTableAdapter = new Fixed_management.FixedDataSetTableAdapters.specificationsTableAdapter();
            fixedDataSetspecificationsTableAdapter.Fill(fixedDataSet.specifications);
            System.Windows.Data.CollectionViewSource specificationsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("specificationsViewSource")));
            specificationsViewSource.View.MoveCurrentToLast();

            Fixed_management.FixedDataSetTableAdapters.modelTableAdapter fixedDataSetmodelTableAdapter = new Fixed_management.FixedDataSetTableAdapters.modelTableAdapter();
            fixedDataSetmodelTableAdapter.Fill(fixedDataSet.model);
            System.Windows.Data.CollectionViewSource modelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("modelViewSource")));
            modelViewSource.View.MoveCurrentToLast();

            Fixed_management.FixedDataSetTableAdapters.unitTableAdapter fixedDataSetunitTableAdapter = new Fixed_management.FixedDataSetTableAdapters.unitTableAdapter();
            fixedDataSetunitTableAdapter.Fill(fixedDataSet.unit);
            System.Windows.Data.CollectionViewSource unitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("unitViewSource")));
            unitViewSource.View.MoveCurrentToLast();

            Fixed_management.FixedDataSetTableAdapters.keeperTableAdapter fixedDataSetkeeperTableAdapter = new Fixed_management.FixedDataSetTableAdapters.keeperTableAdapter();
            fixedDataSetkeeperTableAdapter.Fill(fixedDataSet.keeper);
            System.Windows.Data.CollectionViewSource keeperViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("keeperViewSource")));
            keeperViewSource.View.MoveCurrentToLast();

            Fixed_management.FixedDataSetTableAdapters.supplierTableAdapter fixedDataSetsupplierTableAdapter = new Fixed_management.FixedDataSetTableAdapters.supplierTableAdapter();
            fixedDataSetsupplierTableAdapter.Fill(fixedDataSet.supplier);
            System.Windows.Data.CollectionViewSource supplierViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("supplierViewSource")));
            supplierViewSource.View.MoveCurrentToLast();

            Fixed_management.FixedDataSetTableAdapters.positionTableAdapter fixedDataSetpositionTableAdapter = new Fixed_management.FixedDataSetTableAdapters.positionTableAdapter();
            fixedDataSetpositionTableAdapter.Fill(fixedDataSet.position);
            System.Windows.Data.CollectionViewSource positionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("positionViewSource")));
            positionViewSource.View.MoveCurrentToLast();

            Fixed_management.FixedDataSetTableAdapters.fixed_statuTableAdapter fixedDataSetfixed_statuTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixed_statuTableAdapter();
            fixedDataSetfixed_statuTableAdapter.Fill(fixedDataSet.fixed_statu);
            System.Windows.Data.CollectionViewSource fixed_statuViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("fixed_statuViewSource")));
            fixed_statuViewSource.View.MoveCurrentToLast();

            Fixed_management.FixedDataSetTableAdapters.storage_placeTableAdapter fixedDataSetstorage_placeTableAdapter = new Fixed_management.FixedDataSetTableAdapters.storage_placeTableAdapter();
            fixedDataSetstorage_placeTableAdapter.Fill(fixedDataSet.storage_place);
            System.Windows.Data.CollectionViewSource storage_placeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("storage_placeViewSource")));
            storage_placeViewSource.View.MoveCurrentToLast();

            Fixed_management.FixedDataSetTableAdapters.purchase_wayTableAdapter fixedDataSetpurchase_wayTableAdapter = new Fixed_management.FixedDataSetTableAdapters.purchase_wayTableAdapter();
            fixedDataSetpurchase_wayTableAdapter.Fill(fixedDataSet.purchase_way);
            System.Windows.Data.CollectionViewSource purchase_wayViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("purchase_wayViewSource")));
            purchase_wayViewSource.View.MoveCurrentToLast();
        }
        void quxiao_Click(object sender, RoutedEventArgs e)
        {
            
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

            Fixed_management.FixedDataSetTableAdapters.specificationsTableAdapter fixedDataSetspecificationsTableAdapter = new Fixed_management.FixedDataSetTableAdapters.specificationsTableAdapter();
            System.Windows.Data.CollectionViewSource specificationsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("specificationsViewSource")));

            Fixed_management.FixedDataSetTableAdapters.modelTableAdapter fixedDataSetmodelTableAdapter = new Fixed_management.FixedDataSetTableAdapters.modelTableAdapter();
            System.Windows.Data.CollectionViewSource modelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("modelViewSource")));

            Fixed_management.FixedDataSetTableAdapters.purchase_wayTableAdapter fixedDataSetpurchase_wayTableAdapter = new Fixed_management.FixedDataSetTableAdapters.purchase_wayTableAdapter();
            System.Windows.Data.CollectionViewSource purchase_wayViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("purchase_wayViewSource")));

            Fixed_management.FixedDataSetTableAdapters.unitTableAdapter fixedDataSetunitTableAdapter = new Fixed_management.FixedDataSetTableAdapters.unitTableAdapter();
            System.Windows.Data.CollectionViewSource unitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("unitViewSource")));

            Fixed_management.FixedDataSetTableAdapters.keeperTableAdapter fixedDataSetkeeperTableAdapter = new Fixed_management.FixedDataSetTableAdapters.keeperTableAdapter();
            System.Windows.Data.CollectionViewSource keeperViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("keeperViewSource")));

            Fixed_management.FixedDataSetTableAdapters.supplierTableAdapter fixedDataSetsupplierTableAdapter = new Fixed_management.FixedDataSetTableAdapters.supplierTableAdapter();
            System.Windows.Data.CollectionViewSource supplierViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("supplierViewSource")));

            Fixed_management.FixedDataSetTableAdapters.positionTableAdapter fixedDataSetpositionTableAdapter = new Fixed_management.FixedDataSetTableAdapters.positionTableAdapter();
            System.Windows.Data.CollectionViewSource positionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("positionViewSource")));

            Fixed_management.FixedDataSetTableAdapters.fixed_statuTableAdapter fixedDataSetfixed_statuTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixed_statuTableAdapter();
            System.Windows.Data.CollectionViewSource fixed_statusViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("fixed_statuViewSource")));

            Fixed_management.FixedDataSetTableAdapters.storage_placeTableAdapter fixedDataSetstorage_placeTableAdapter = new Fixed_management.FixedDataSetTableAdapters.storage_placeTableAdapter();
            System.Windows.Data.CollectionViewSource storage_placeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("storage_placeViewSource")));
            var nature = (from c in fixedDataSet.nature where c.nature == natureC1ComboBox.Text select c).Count();
            var category = (from c in fixedDataSet.category where c.category == categoryC1ComboBox.Text select c).Count();
            var designation = (from c in fixedDataSet.designation where c.designation == designationC1ComboBox.Text select c).Count();
            var specifications = (from c in fixedDataSet.specifications where c.specifications == specifications_IDC1ComboBox.Text select c).Count();
            var model = (from c in fixedDataSet.model where c.model == model_IDC1ComboBox.Text select c).Count();
            var purchase_way = (from c in fixedDataSet.purchase_way where c.purchase_way == purchase_way_IDC1ComboBox.Text select c).Count();
            var unit = (from c in fixedDataSet.unit where c.unit == unit_IDC1ComboBox.Text select c).Count();
            var keeper = (from c in fixedDataSet.keeper where c.keeper == keeper_IDC1ComboBox.Text select c).Count();
            var supplier = (from c in fixedDataSet.supplier where c.supplier == supplier_IDC1ComboBox.Text select c).Count();
            var position = (from c in fixedDataSet.position where c.position == position_IDC1ComboBox.Text select c).Count();
            var fixed_statu = (from c in fixedDataSet.fixed_statu where c.fixed_statu == fixed_statu_IDC1ComboBox.Text select c).Count();
            var storage_place = (from c in fixedDataSet.storage_place where c.storage_place == storage_place_IDC1ComboBox.Text select c).Count();
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
            if (specifications == 0)
            {
                fixedDataSet.specifications.AddspecificationsRow(specifications_IDC1ComboBox.Text);
                fixedDataSetspecificationsTableAdapter.Update(fixedDataSet.specifications);
                specificationsViewSource.View.MoveCurrentToLast();
            }
            if (model == 0)
            {
                fixedDataSet.model.AddmodelRow(model_IDC1ComboBox.Text);
                fixedDataSetmodelTableAdapter.Update(fixedDataSet.model);
                modelViewSource.View.MoveCurrentToLast();
            }
            if (purchase_way == 0)
            {
                fixedDataSet.purchase_way.Addpurchase_wayRow(purchase_way_IDC1ComboBox.Text);
                fixedDataSetpurchase_wayTableAdapter.Update(fixedDataSet.purchase_way);
                purchase_wayViewSource.View.MoveCurrentToLast();
            }
            if (unit == 0)
            {
                fixedDataSet.unit.AddunitRow(unit_IDC1ComboBox.Text);
                fixedDataSetunitTableAdapter.Update(fixedDataSet.unit);
                unitViewSource.View.MoveCurrentToLast();
            }
            if (keeper == 0)
            {
                fixedDataSet.keeper.AddkeeperRow(keeper_IDC1ComboBox.Text);
                fixedDataSetkeeperTableAdapter.Update(fixedDataSet.keeper);
                keeperViewSource.View.MoveCurrentToLast();
            }
            if (supplier == 0)
            {
                fixedDataSet.supplier.AddsupplierRow(supplier_IDC1ComboBox.Text);
                fixedDataSetsupplierTableAdapter.Update(fixedDataSet.supplier);
                supplierViewSource.View.MoveCurrentToLast();
            }
            if (position == 0)
            {
                fixedDataSet.position.AddpositionRow(position_IDC1ComboBox.Text);
                fixedDataSetpositionTableAdapter.Update(fixedDataSet.position);
                positionViewSource.View.MoveCurrentToLast();
            }
            if (fixed_statu == 0)
            {
                fixedDataSet.fixed_statu.Addfixed_statuRow(fixed_statu_IDC1ComboBox.Text);
                fixedDataSetfixed_statuTableAdapter.Update(fixedDataSet.fixed_statu);
                fixed_statusViewSource.View.MoveCurrentToLast();
            }
            if (specifications == 0)
            {
                fixedDataSet.storage_place.Addstorage_placeRow(storage_place_IDC1ComboBox.Text);
                fixedDataSetstorage_placeTableAdapter.Update(fixedDataSet.storage_place);
                storage_placeViewSource.View.MoveCurrentToLast();
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
            if (specifications_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "资产规格 ";
            }
            if (model_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "资产型号 ";
            }
            if (purchase_way_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "购置方式 ";
            }
            if (unit_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "计量单位 ";
            }
            if (keeper_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "保管人 ";
            }
            if (supplier_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "供应商 ";
            }
            if (position_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "所在位置 ";
            }
            if (fixed_statu_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "资产状态 ";
            }
            if (storage_place_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "存放地点 ";
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
