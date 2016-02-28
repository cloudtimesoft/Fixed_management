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
    /// Exit_assets.xaml 的交互逻辑
    /// </summary>
    public partial class Exit_assets : UserControl
    {
        public Exit_assets()
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
            Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter fixednameTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter();
            fixednameTableAdapter.Fill(fixedDataSet.fixedname);
            System.Windows.Data.CollectionViewSource fixednameViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("fixednameViewSource")));
            fixednameViewSource.View.MoveCurrentToFirst();

            Fixed_management.FixedDataSetTableAdapters.exit_wayTableAdapter fixedDataSetexit_wayTableAdapter = new Fixed_management.FixedDataSetTableAdapters.exit_wayTableAdapter();
            fixedDataSetexit_wayTableAdapter.Fill(fixedDataSet.exit_way);
            System.Windows.Data.CollectionViewSource exit_wayViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("exit_wayViewSource")));
            exit_wayViewSource.View.MoveCurrentToFirst();

            Fixed_management.FixedDataSetTableAdapters.operatorTableAdapter fixedDataSetoperatorableAdapter = new Fixed_management.FixedDataSetTableAdapters.operatorTableAdapter();
            fixedDataSetoperatorableAdapter.Fill(fixedDataSet._operator);
            System.Windows.Data.CollectionViewSource operatorViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("operatorViewSource")));
            operatorViewSource.View.MoveCurrentToFirst();


            fixednameDataGrid.CanUserAddRows = false;
            exit_dateDatePicker.SelectedDate = DateTime.Now;
        }
        private void checkmultitable()
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            // 将数据加载到表 nature 中。可以根据需要修改此代码。
            Fixed_management.FixedDataSetTableAdapters.exit_wayTableAdapter fixedDataSetexit_wayTableAdapter = new Fixed_management.FixedDataSetTableAdapters.exit_wayTableAdapter();
            System.Windows.Data.CollectionViewSource exit_wayViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("exit_wayViewSource")));

            Fixed_management.FixedDataSetTableAdapters.operatorTableAdapter fixedDataSetoperatorTableAdapter = new Fixed_management.FixedDataSetTableAdapters.operatorTableAdapter();
            System.Windows.Data.CollectionViewSource operatorViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("operatorViewSource")));

            var exit_way = (from c in fixedDataSet.exit_way where c.way == exit_way_IDC1ComboBox.Text select c).Count();
            var _operator = (from c in fixedDataSet._operator where c._operator == operator_IDC1ComboBox.Text select c).Count();
            if (exit_way == 0)
            {
                fixedDataSet.exit_way.Addexit_wayRow(exit_way_IDC1ComboBox.Text);
                fixedDataSetexit_wayTableAdapter.Update(fixedDataSet.exit_way);
                fixedDataSetexit_wayTableAdapter.Fill(fixedDataSet.exit_way);
                exit_wayViewSource.View.MoveCurrentToLast();

            }

            if (_operator == 0)
            {
                fixedDataSet._operator.AddoperatorRow(operator_IDC1ComboBox.Text);
                fixedDataSetoperatorTableAdapter.Update(fixedDataSet._operator);
                fixedDataSetoperatorTableAdapter.Fill(fixedDataSet._operator);
                operatorViewSource.View.MoveCurrentToLast();
            }
        }
        private bool checknull()
        {
            bool check_status = true;
            string status_err = "";
            if (exit_way_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "退出方式 ";
            }

            if (operator_IDC1ComboBox.Text == null)
            {
                check_status = false;
                status_err += "经办人 ";
            }

            if (exit_dateDatePicker.SelectedDate == null)
            {
                check_status = false;
                status_err += "退出日期 ";
            }
            if (!check_status)
            {
                MessageBox.Show(status_err + "不能为空！");
            }

            
            return check_status;   
        }

        private void fix_outtool_Click(object sender, RoutedEventArgs e)
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
                    if ((bool)tbOper.IsChecked)
                    {

                        var Voperator = from c in fixedDataSet._operator where c._operator == operator_IDC1ComboBox.Text select c;

                        int Ioperator = 0;
                        foreach (var a in Voperator)
                        {
                            Ioperator = a.operator_ID;
                            break;
                        }

                        var Vexit_way = from c in fixedDataSet.exit_way where c.way == exit_way_IDC1ComboBox.Text select c;
                        int Iexit_way = 0;
                        foreach (var a in Vexit_way)
                        {
                            Iexit_way = a.exit_way_ID;
                            break;
                        }

                        var select_count = from c in fixedDataSet._fixed where c.fixed_ID == fixedname_id select c;
                        foreach (var enable in select_count)
                        {
                            enable.enable_status = "2";
                            enable.exit_date = DateTime.Parse(exit_dateDatePicker.Text);
                            enable.operator_ID = Ioperator;
                            enable.exit_way_ID = Iexit_way;
                        }

                    }
                }
                fixedTableAdapter.Update(fixedDataSet._fixed);
                fixedDataSet._fixed.AcceptChanges();
                fixedTableAdapter.Fill(fixedDataSet._fixed);

            }
            Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter fixednameTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter();
            fixedDataSet.fixedname.AcceptChanges();
            fixednameTableAdapter.Fill(fixedDataSet.fixedname);
        }

        private void exit_select_Click(object sender, RoutedEventArgs e)
        {
            Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            if (textBox1.Text != "")
            {
                var s = from c in fixedDataSet.fixedname where c.storage_place == textBox1.Text || c.barcode == textBox1.Text || c.limit == int.Parse(textBox1.Text) || c.fixed_number == int.Parse(textBox1.Text) || c.fixed_vale == textBox1.Text || c.factory_number == textBox1.Text || c.fixed_encoding == textBox1.Text || c.warranty == int.Parse(textBox1.Text) || c.account_number == textBox1.Text || c.fixed_asset == textBox1.Text || c.card_number == textBox1.Text || c.nature == textBox1.Text || c.category == textBox1.Text || c.specifications == textBox1.Text || c.designation == textBox1.Text || c.model == textBox1.Text || c.unit == textBox1.Text || c.purchase_way == textBox1.Text || c.keeper == textBox1.Text || c.supplier == textBox1.Text || c.position == textBox1.Text || c.fixed_status == textBox1.Text || c.user == textBox1.Text || c._operator == textBox1.Text || c.affiliated == textBox1.Text || c.department == textBox1.Text || c.content == textBox1.Text select c;
                fixednameDataGrid.ItemsSource = s;
            }
            else
            {
                var s = from c in fixedDataSet.fixed_del_query select c;
                fixednameDataGrid.ItemsSource = s;
            }
        }
    }
}
