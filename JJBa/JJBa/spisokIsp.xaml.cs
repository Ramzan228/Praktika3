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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JJBa
{
    /// <summary>
    /// Логика взаимодействия для spisokIsp.xaml
    /// </summary>
    public partial class spisokIsp : UserControl
    {
        public spisokIsp()
        {
            InitializeComponent();
        }
        private DataSet mh = new DataSet();
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MParent rp = (MParent)Application.Current.Windows[1];
            rp.forma.Content = rp.mn.Mtop;
        }
        public void load()
        {
            Gr.ItemsSource = null;
            mh.Tables.Clear();
            mh.Tables.Add(Connect.read("IspolDB"));
            mh.Tables.Add(Connect.read("MenejDB"));
            mh.Tables.Add(new DataTable());

            mh.Tables[2].Columns.Add(new DataColumn("ФИО исполнителя"));
            mh.Tables[2].Columns.Add(new DataColumn("Грейд"));
            mh.Tables[2].Columns.Add(new DataColumn("ФИО менеджера"));
            foreach (DataRow dr in mh.Tables[0].Rows)
            {
                string s="";
                foreach (DataRow drs in mh.Tables[1].Rows)
                {
                    if (drs[0].ToString() == dr[5].ToString())
                        s = drs[3].ToString();
                }
                object[] ob = {dr[4],dr[3], s};
                mh.Tables[2].Rows.Add(ob);
            }
            Gr.ItemsSource = mh.Tables[2].AsDataView();

        }
    }
}
