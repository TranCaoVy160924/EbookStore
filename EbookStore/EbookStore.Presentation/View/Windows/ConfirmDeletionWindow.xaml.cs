using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EbookStore.Presentation.View
{
    /// <summary>
    /// Interaction logic for ConfirmDeletion.xaml
    /// </summary>
    public partial class ConfirmDeletionWindow : Window
    {
        public ConfirmDeletionWindow()
        {
            InitializeComponent();
        }

        private void No_Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Yes_Button_Click(Object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
