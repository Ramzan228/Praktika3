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

namespace JJBa
{
    /// <summary>
    /// Логика взаимодействия для MParent.xaml
    /// </summary>
    public partial class MParent : Window
    {
        public MParent()
        {
            new Log().Show();
            this.Hide();
            InitializeComponent();
        }

        List<Label> lbs = new List<Label>();
        public static int id=-1;
        public static int idd = -1;
        public static List<string> log = new List<string>();
        public static string name = "";
        public Good mn = new Good();
        public Main mns = new Main();
        public SZad szd = new SZad();
        public spisokIsp spisok = new spisokIsp();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mn.load();
            Application.Current.MainWindow = this;
            lbs.Add(mn.L1);
            forma.Content = mn.Mtop;
        }
        public void load(string s)
        {
            lbs[0].Content = lbs[0].Content + s+"!";

        }

        private void forma_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
