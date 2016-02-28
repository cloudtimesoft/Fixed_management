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
using System.Data;

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

            fixed_exitDataGrid.CanUserAddRows = false;

            Fixed_management.FixedDataSetTableAdapters.fixed_exitTableAdapter fixednameTableAdapter = new Fixed_management.FixedDataSetTableAdapters.fixed_exitTableAdapter();
            fixedDataSet.fixed_exit.AcceptChanges();
            fixed_exitTableAdapter.Fill(fixedDataSet.fixed_exit);
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            ExportDataGridSaveAs(true, fixed_exitDataGrid);
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
                //var source = (grid.ItemsSource as IList);
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
                    for (int i = 0; i < grid.Columns.Count; i++)
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

    }
}
