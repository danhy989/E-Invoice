using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoEInvoicing
{
    public class DataProvide
    {
        private DataProvide() { }
        private static DataProvide instance;
        public static DataProvide Instance
        {
            get
            {
                if (instance == null) instance = new DataProvide();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
       
        public string connectionStr = @"Data Source=DANHYPC;Initial Catalog=demoEInvoicing;Integrated Security=True";
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
        public DataSet ExecuteQueryDataSet(string query, object[] parameter = null)
        {

            DataSet data = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }

        public string ExecuteReader(string query)
        {
            string data = null;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                SqlCommand Comm1 = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                if (DR1.Read())
                {
                    data = DR1.GetValue(0).ToString();
                }
                connection.Close();
            }
            return data;
        }
        public string ExecuteReaderString(string query)
        {
            string data = null;
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                SqlCommand Comm1 = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                while (DR1.Read())
                {
                    data += DR1.GetValue(0).ToString() + "@";
                }
                connection.Close();
            }
            return data;
        }

        public List<string> ExecuteReaderListString(string query)
        {
            List<string> strList = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                SqlCommand Comm1 = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader DR1 = Comm1.ExecuteReader();
                while (DR1.Read())
                {
                    strList.Add(DR1.GetValue(0).ToString());
                }
                connection.Close();
            }
            return strList;
        }
    }
}
