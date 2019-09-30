using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CoffeeShopCRUDOperation.BLL;



namespace CoffeeShopCRUDOperation.Repository
{
    public class CustomerRepository
    {
        string connectionString = @"Server= DESKTOP-LE66CE0; Database= CoffeeShop_07; Integrated Security=True";

        public bool AddCustomer(string name, string contact, string address)
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            bool isAdded = false;

            string commandString = @"INSERT INTO Customers (Name,Contact,Address) VALUES ('" + name + "','" + contact + "','" + address + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted == 1)
            {
                isAdded = true;
            }
            sqlConnection.Close();

            return isAdded;

        }
        public bool IsNameExists(string name)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            bool exists = false;
            string commandString = @"SELECT * FROM Customers WHERE Name = '" + name + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                exists = true;
            }
            sqlConnection.Close();

            return exists;
        }

        public bool DeleteCustomers(string name)
        {
            bool deleted = false;
            
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string commandString = @"DELETE FROM Customers WHERE Name= '" + name+ "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            int isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted == 1)
            {
                deleted = true;
            }
            sqlConnection.Close();
            return deleted;
        }
        public bool UpdateCustomer(string name,string contact,string address,string id)
        {
            bool update = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string commandString = @"UPDATE Customers SET Name= '" + name + "',Contact='" + contact + "',Address='" + address + "' WHERE Id=" +id+ " ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            int isExecuted = sqlCommand.ExecuteNonQuery();

            if (isExecuted == 1)
            {
                update = true;
            }
            sqlConnection.Close();
            return update;
        }
         public DataTable SearchCustomer(string name)
         {
            
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string commandString = @"SELECT * FROM Customers WHERE Name= '" + name + "'";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);          
            sqlConnection.Close();
            return dataTable;


        }
        public DataTable ShowCustomer()
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string commandString = @"SELECT * FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
    }
}
