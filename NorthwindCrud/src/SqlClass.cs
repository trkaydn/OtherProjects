using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Northwind
{
    public class SqlClass
    {
        private static string _connectionString = "Data Source=TARIK-PC;Initial Catalog=Northwind;Integrated Security=True";
        SqlConnection connection = new SqlConnection(_connectionString);

        public bool AddCustomer(string id, string compname, string contname, string conttitle, string address, string city, string region, string postalcode, string country, string phone, string fax)
        {
            int control = 0;
           
                using (connection)
                {

                    connection.Open();
                    SqlCommand AddCommand = new SqlCommand("insert into Customers values ('" + id + "','" + compname + "','" + contname + "','" + conttitle + "','" + address + "','" + city + "','" + region + "','" + postalcode + "','" + country + "','" + phone + "','" + fax + "')", connection);
                    control = AddCommand.ExecuteNonQuery();
                }
                return control > 0;
         
        }

        public List<string> GetCustomer(string id)
        {
            List<string> values = new List<string>();

            try
            {
                connection.Open();
                SqlCommand GetCommand = new SqlCommand("select * from customers where CustomerID='" + id + "'", connection);
                SqlDataReader reader = GetCommand.ExecuteReader();
                reader.Read();

                values.Add(reader["CompanyName"].ToString());
                values.Add(reader["ContactName"].ToString());
                values.Add(reader["ContactTitle"].ToString());
                values.Add(reader["Address"].ToString());
                values.Add(reader["City"].ToString());
                values.Add(reader["Region"].ToString());
                values.Add(reader["PostalCode"].ToString());
                values.Add(reader["Country"].ToString());
                values.Add(reader["Phone"].ToString());
                values.Add(reader["Fax"].ToString());
                connection.Close();
                return values;
            }
            catch (Exception)
            { return values; }


        }

        public bool UpdateCustomer(string id, string compname, string contname, string conttitle, string address, string city, string region, string postalcode, string country, string phone, string fax)
        {
            int control = 0;
            using (connection)
            {
                connection.Open();
                SqlCommand UpdateCommand = new SqlCommand("update Customers set CompanyName='" + compname + "',ContactName='" + contname + "',ContactTitle='" + conttitle + "',Address='" + address + "',City='" + city + "',Region='" + region + "',PostalCode='" + postalcode + "',Country='" + country + "',Phone='" + phone + "',Fax='" + fax + "' where CustomerID='" + id + "'", connection);
                control = UpdateCommand.ExecuteNonQuery();
            }
            return control > 0;

        }

        public bool DeleteCustomer(string id)
        {

            int control = 0;
            using (connection)
            {
                connection.Open();
                SqlCommand DeleteCommand = new SqlCommand("delete from Customers where CustomerID='" + id + "'", connection);
                control = DeleteCommand.ExecuteNonQuery();
            }


            return control > 0;
        }



    }
}
