﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JJBa
{
    class Connect
    {
        private static SqlConnectionStringBuilder connS = new SqlConnectionStringBuilder()
        {
             
            DataSource = "303-8",
            InitialCatalog = "Nice",
            IntegratedSecurity = true
        };
        public static string login(string log, string pass)
        {
            using (SqlConnection conn = new SqlConnection(connS.ConnectionString))
            {
                string lol = "";
                conn.Open();
                string selectString = $"SELECT * FROM dbo.IspolDB WHERE '{log}' = Логин_исполнителя AND '{pass}' = Пароль_исполнителя";
                string selectString_2 = $"SELECT * FROM dbo.MenejDB WHERE '{log}' = Логин_менеджера AND '{pass}' = Пароль_менеджера";
                SqlCommand cmd = new SqlCommand(selectString, conn);
                SqlDataReader sql = cmd.ExecuteReader();
                if (sql.HasRows)
                {
                    sql.Read();
                    MParent.idd = Int16.Parse(sql[0].ToString());
                    MParent.id = 0;
                    MParent.log.Clear();
                    MParent.log.Add(sql[1].ToString());
                    lol =  sql[4].ToString();
                }
                else
                {
                    sql.Close();
                    cmd = new SqlCommand(selectString_2, conn);
                    sql = cmd.ExecuteReader();
                    if (sql.HasRows)
                    {
                        sql.Read();
                        MParent.idd = Int16.Parse(sql[0].ToString());
                        MParent.id = 1;
                        MParent.log.Clear();
                        MParent.log.Add(sql[1].ToString());
                        lol = sql[3].ToString();
                    }
                }
                sql.Close();
                conn.Close();
                if (!String.IsNullOrEmpty(lol)) return lol;
                return "";
            }
        }
        public static DataTable read(string name)
        {
            using (SqlConnection conn = new SqlConnection(connS.ConnectionString))
            {
                DataTable dt = new DataTable();
                conn.Open();
                string d = $"Select * From {name}";
                SqlCommand cmd = new SqlCommand(d, conn);
                using (SqlDataAdapter ada = new SqlDataAdapter(cmd))
                {
                    dt.Clear();
                    ada.Fill(dt);

                }

                conn.Close();
                return dt;
            }
        }
        public static void load(DataRow name)
        {
            using (SqlConnection conn = new SqlConnection(connS.ConnectionString))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                DataTable dt = new DataTable();
                conn.Open();
                string d = $"UPDATE RabDB Set [Junior_мин_ЗП] = '{name[1]}', [Middle_мин_ЗП] = '{name[2]}', [Senior_мин_ЗП] = '{name[3]}', [Коэффициент_для_Анализ_и_проектирование]= '{name[4]}', [Коэффициент_для_Установка_оборудования] = '{name[5]}', [Коэффициент_для_Техническое_обслуживание_и_сопровождение] = '{name[6]}', [Коэффициент_времени] = '{name[7]}', [Коэффициент_сложности] = '{name[8]}', [Коэффициент_для_перевода_в_денежный_эквивалент] = '{name[9]}' WHERE Id_d = '{name[0]}'";
                new SqlCommand(d, conn).ExecuteNonQuery(); 
                MessageBox.Show("Успешно!");
                conn.Close();

            }
        }
    }
}
