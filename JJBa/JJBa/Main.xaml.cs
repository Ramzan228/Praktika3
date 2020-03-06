using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }
        private DataSet ds = new DataSet();
        private List<TextBox> tb = new List<TextBox>();
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            checkload();

        }
        public void checkload()
        {
            tb.Clear();
            tb.Add(T1); tb.Add(T2); tb.Add(T3);
            tb.Add(T4); tb.Add(T5); tb.Add(T6);
            tb.Add(T7); tb.Add(T8); tb.Add(T9);
            for (int i = 0; i < tb.Count; i++)
            {
                tb[i].MaxLength = 10;
                tb[i].MaxLines = 1;
            }
            loaddb();
        }
        private void loaddb()
        {


            ds.Tables.Clear();
            ds.Tables.Add(Connect.read("RabDB"));
            TextUpdate();
        }

        

        private void idc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TextUpdate()
        {

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            
                for (int i = 0; i < tb.Count; i++)
                {
                    tb[i].Text = Math.Round(Double.Parse(ds.Tables[0].Rows[MParent.idd-1][i+1].ToString()), 2).ToString();
                }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            DataRow dr = ds.Tables[0].NewRow();
            bool doDoHasDoHasMesh = true;
            try
            {
                dr[0] = MParent.idd;
                for (int i = 0; i < tb.Count; i++)
                {
                    dr[i+1] = Double.Parse(tb[i].Text.Replace(',', '.'));
                }

            }
            catch (Exception)
            {
                doDoHasDoHasMesh = false;
                MessageBox.Show("Проверьте правильность данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            //MessageBox.Show(dr[0] + ", " + dr[1] + ", " + dr[2] + ", " + dr[3] + ", " + dr[4] + ", " + dr[5] + ", " + dr[6] + ", " + dr[7] + ", " + dr[8] + ", " + dr[9]);
            if (doDoHasDoHasMesh)
            {
                Connect.load(dr);
                loaddb();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MParent mp = (MParent)Application.Current.Windows[1];
            mp.forma.Content = mp.mn.Mtop;
        }
    }
}
