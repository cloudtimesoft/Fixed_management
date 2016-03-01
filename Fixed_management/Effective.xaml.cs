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
using System.IO;
using System.Collections;
using System.Data;
using System.Data.Odbc;
using Microsoft.Office.Tools.Excel;

namespace Fixed_management
{
    /// <summary>
    /// Effective.xaml 的交互逻辑
    /// </summary>
    /// 

    public partial class Effective : UserControl
    {
        public Effective()
        {
            InitializeComponent();
        }

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
            select.Margin = new Thickness(SystemParameters.PrimaryScreenWidth - 100, 10, 0, 0);
            textBox1.Margin = new Thickness(SystemParameters.PrimaryScreenWidth - 230, 10, 0, 0);
          }

        private void prit_Click(object sender, RoutedEventArgs e)
        {
            //PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == true)
            //{
            //    var tbl = fixednameDataGrid;
            //    var size = new Size(fixednameDataGrid.ActualWidth, fixednameDataGrid.ActualHeight);
            //    tbl.Measure(size);
            //    tbl.Arrange(new Rect(new Point(0, 0), size));

            //    printDialog.PrintVisual(tbl, "Print Test");

            ExportDataGridSaveAs(true, fixednameDataGrid);
        }
        private static string FormatCsvField(string data)
        {
            return String.Format("\"{0}\"", data.Replace("\"", "\"\"\"").Replace("\n", "").Replace("\r", ""));
        }
        /// <summary>
        /// 导出DataGrid数据到Excel
        /// </summary>
        /// <param name="withHeaders">是否需要表头</param>
        /// <param name="grid">DataGrid</param>
        /// <param name="dataBind"></param>
        /// <returns>Excel内容字符串</returns>
        public static string ExportDataGrid(bool withHeaders, System.Windows.Controls.DataGrid grid, bool dataBind)
        {

            
            //Fixed_management.FixedDataSet fixedDataSet = ((Fixed_management.FixedDataSet)(this.FindResource("fixedDataSet")));
            //// 将数据加载到表 nature 中。可以根据需要修改此代码。
            //Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter fixednameTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixednameTableAdapter();
            //fixednameTableAdapter.Fill(fixedDataSet.fixedname);
           
            try
            {
                var strBuilder = new System.Text.StringBuilder();
                var source = (grid.ItemsSource as IList);
                //if (source == null) return "";
                var headers = new List<string>();
                List<string> bt = new List<string>();
                foreach (var hr in grid.Columns)
                {
                    //   DataGridTextColumn textcol = hr. as DataGridTextColumn;
                    headers.Add(hr.Header.ToString());
                    if (hr is DataGridTextColumn)//列绑定数据
                    {
                        DataGridTextColumn textcol = hr as DataGridTextColumn;
                        if (textcol != null)
                            bt.Add((textcol.Binding as Binding).Path.Path.ToString());		//获取绑定源	  

                    }
                    else if (hr is DataGridTemplateColumn)
                    {
                        if (hr.Header.Equals("操作"))
                            bt.Add("Id");
                    }
                    else
                    {
                    }
                }
                strBuilder.Append(String.Join(",", headers.ToArray())).Append("\r\n");

                var csvRow = new List<string>();
                foreach (var t in grid.Items)
                {
                    var a = t as DataRowView;
                    for (int i = 0; i < grid.Columns.Count;i++ )
                    {
                        csvRow.Add(a[i].ToString());
                        
                    }
                    //csvRow[csvRow.Count()-1] = csvRow.Last() + "\r\n";
                    strBuilder.Append(String.Join(",", csvRow.ToArray())).Append("\r\n");
                    csvRow.Clear();
                }
                //strBuilder.Append(String.Join(",", csvRow.ToArray())).Append("\r\n");



                //foreach (var data in source)
                //{
                   
                //    //var csvRow = new List<string>();
                //    //foreach (var ab in bt)
                //    //{
                //    //    string s = ReflectionUtil.GetProperty(data, ab).ToString();
                //    //    if (s != null)
                //    //    {
                //    //        csvRow.Add(FormatCsvField(s));
                //    //    }
                //    //    else
                //    //    {
                //    //        csvRow.Add("\t");
                //    //    }
                //    //}
                //    //strBuilder.Append(String.Join(",", csvRow.ToArray())).Append("\r\n");
                //    // strBuilder.Append(String.Join(",", csvRow.ToArray())).Append("\t");
                //}
                return strBuilder.ToString();
            }
            catch (Exception ex)
            {
                //LogHelper.Error(ex);
                return "";
            }
        }

        /// <summary>
        /// 导出DataGrid数据到Excel为CVS文件
        /// 使用utf8编码 中文是乱码 改用Unicode编码
        /// 
        /// </summary>
        /// <param name="withHeaders">是否带列头</param>
        /// <param name="grid">DataGrid</param>
        public static void ExportDataGridSaveAs(bool withHeaders, System.Windows.Controls.DataGrid grid)
        {
            try
            {
                string data = ExportDataGrid(true, grid, true);
                var sfd = new Microsoft.Win32.SaveFileDialog
                {
                    DefaultExt = "csv",
                    Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*",
                    FilterIndex = 1
                };
                if (sfd.ShowDialog() == true)
                {
                    using (Stream stream = sfd.OpenFile())
                    {
                        using (var writer = new StreamWriter(stream, System.Text.Encoding.Unicode))
                        {
                            data = data.Replace(",", "\t");
                            writer.Write(data);
                            writer.Close();
                        }
                        stream.Close();
                    }
                }
                MessageBox.Show("导出成功！");
            }
            catch (Exception ex)
            {
                //LogHelper.Error(ex);
            }
        }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            //C1.WPF.C1Window newselect = new C1.WPF.C1Window();
            //newselect.Name = "selecteff";
            //newselect.Width = 400;
            //newselect.Height = 500;
            //newselect.IsResizable = false;
            //newselect.ShowMaximizeButton = false;
            //newselect.ShowMinimizeButton = false;
            //newselect.Margin = new Thickness(SystemParameters.PrimaryScreenWidth / 2d - 250, SystemParameters.PrimaryScreenHeight / 2d - 250, 0, 0);
            //newselect.Show();



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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           
        }



        ////获取表格中的数据  
        //public System.Data.DataTable LoadExcel(string pPath)
        //{

        //    string connString = "Driver={Driver do Microsoft Excel(*.xls)};DriverId=790;SafeTransactions=0;ReadOnly=1;MaxScanRows=16;Threads=3;MaxBufferSize=2024;UserCommitSync=Yes;FIL=excel 8.0;PageTimeout=5;";  //连接字符串    

        //    //简单解释下这个连续字符串，Driver={Driver do Microsoft Excel(*.xls)} 这种连接写法不需要创建一个数据源DSN，DRIVERID表示驱动ID，Excel2003后都使用790，  

        //    //FIL表示Excel文件类型，Excel2007用excel 8.0，MaxBufferSize表示缓存大小， 如果你的文件是2010版本的，也许会报错，所以要找到合适版本的参数设置。  

        //    connString += "DBQ=" + pPath; //DBQ表示读取Excel的文件名（全路径）  
        //    OdbcConnection conn = new OdbcConnection(connString);
        //    OdbcCommand cmd = new OdbcCommand();
        //    cmd.Connection = conn;
        //    //获取Excel中第一个Sheet名称，作为查询时的表名  
        //    string sheetName = this.GetExcelSheetName(pPath);
        //    string sql = "select * from [" + sheetName.Replace('.', '#') + "$]";
        //    cmd.CommandText = sql;
        //    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        da.Fill(ds);
        //        return ds.Tables[0];    //返回Excel数据中的内容，保存在DataTable中  
        //    }
        //    catch (Exception x)
        //    {
        //        ds = null;
        //        throw new Exception("从Excel文件中获取数据时发生错误！可能是Excel版本问题，可以考虑降低版本或者修改连接字符串值");
        //    }
        //    finally
        //    {
        //        cmd.Dispose();
        //        cmd = null;
        //        da.Dispose();
        //        da = null;
        //        if (conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }
        //        conn = null;
        //    }
        //}

        //// 获取工作表名称  
        //private string GetExcelSheetName(string pPath)
        //{
        //    //打开一个Excel应用  
        //    Microsoft.Office.Interop.Excel.Application excelApp;
        //    Workbook excelWB;//创建工作簿（WorkBook：即Excel文件主体本身）  
        //    Workbooks excelWBs;
        //    Worksheet excelWS;//创建工作表（即Excel里的子表sheet）  

        //    Sheets excelSts;

        //    excelApp = new Microsoft.Office.Interop.Excel.Application();
        //    if (excelApp == null)
        //    {
        //        throw new Exception("打开Excel应用时发生错误！");
        //    }
        //    excelWBs = excelApp.Workbooks;
        //    //打开一个现有的工作薄  
        //    excelWB = excelWBs.Add(pPath);
        //    excelSts = excelWB.Sheets;
        //    //选择第一个Sheet页  
        //    excelWS = excelSts.get_Item(1);
        //    string sheetName = excelWS.Name;

        //    ReleaseCOM(excelWS);
        //    ReleaseCOM(excelSts);
        //    ReleaseCOM(excelWB);
        //    ReleaseCOM(excelWBs);
        //    excelApp.Quit();
        //    ReleaseCOM(excelApp);
        //    return sheetName;
        //}

        //// 释放资源  
        //private void ReleaseCOM(object pObj)
        //{
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(pObj);
        //    }
        //    catch
        //    {
        //        throw new Exception("释放资源时发生错误！");
        //    }
        //    finally
        //    {
        //        pObj = null;
        //    }
        //}  

     
   
    }
}
