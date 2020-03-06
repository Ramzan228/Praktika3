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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JJBa
{
    /// <summary>
    /// Логика взаимодействия для Good.xaml
    /// </summary>
    public partial class Good : UserControl
    {
        public Good()
        {
            InitializeComponent();
        }
        MParent mp;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            mp.mns.checkload();
            mp.forma.Content = mp.mns.gtop;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        public void load()
        {

            mp = (MParent)Application.Current.Windows[1];
            
            if (MParent.id == 0)
            {
                btn1.Visibility = Visibility.Hidden;
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            mp.forma.Content = mp.szd.gtop;
            mp.szd.load();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            mp.forma.Content = mp.spisok.gtop;
            mp.spisok.load();
        }
    }
}
