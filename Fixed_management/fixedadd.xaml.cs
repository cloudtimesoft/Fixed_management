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

        private void barcode_btn_Click(object sender, RoutedEventArgs e)
        {
          

        }

        private void nature_btn_Click(object sender, RoutedEventArgs e)
        {
            C1.WPF.C1Window newnature = new C1.WPF.C1Window();
            newnature.Width = 400;
            newnature.Height = 500;
            newnature.Margin = new Thickness(SystemParameters.PrimaryScreenWidth / 2d - 250, SystemParameters.PrimaryScreenHeight / 2d - 250, 0, 0);
            newnature.ShowModal();
            ListBox naturelist = new ListBox();
            naturelist.Width = 390;
            naturelist.Height = 400;
            naturelist.VerticalAlignment = VerticalAlignment.Top;
            newnature.Content = naturelist;
        }

        private void textBox16_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
