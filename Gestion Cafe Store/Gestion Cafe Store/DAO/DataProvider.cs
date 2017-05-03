using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cafe_Store.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;    // Dong goi bang phim tat Ctrl + R + E

        private string strConn = "Data Source=ServerName\\SQLEXPRESS; Initial Catalog=CafeStore(DB Name); Integrated Security=True";

        public static DataProvider Instance
        {
            get
            {
                if (instance == null) instance = new DataProvider(); return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private DataProvider()
        {

        }

        public DataTable ExecuteQuery(string strQuery, object[] parameter = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(strQuery, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                if (parameter != null)
                {
                    string[] listPara = strQuery.Split(' ');
                    int i = 0;

                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                adapter.Fill(dt);

                conn.Close();
            }
            return dt;
        }

        public int ExecuteNonQuery(string strQuery, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(strQuery, conn);

                if (parameter != null)
                {
                    string[] listPara = strQuery.Split(' ');
                    int i = 0;

                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();

                conn.Close();

            }

            return data;
        }

        public object ExecuteScala(string strQuery, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(strQuery, conn);

                if (parameter != null)
                {
                    string[] listPara = strQuery.Split(' ');
                    int i = 0;

                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar();

                conn.Close();

            }

            return data;
        }
    }
}

