using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopCRUDOperation
{
    public partial class Item : Form
    {
        string connectionString = @"Server= DESKTOP-LE66CE0; Database= CoffeeShop_07; Integrated Security=True";
        public Item()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddItem();
        }
        private void showButton_Click(object sender, EventArgs e)
        {
            ShowItem();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteItem();
            ShowItem();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateItem();
            ShowItem();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchItem();
        }
        private void AddItem()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string commandString1 = @"SELECT * FROM Items WHERE Item = '" + itemComboBox.Text + "'";
            SqlCommand sqlCommand1 = new SqlCommand(commandString1, sqlConnection);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand1);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                MessageBox.Show("Dublicate Item"); return;
            }
            else
            {
                string commandString = @"INSERT INTO Items (Item,price) VALUES ('" + itemComboBox.Text + "','" + priceTextBox.Text + "')";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted == 1)
                {
                    MessageBox.Show("saved Successfully");
                }
                else
                {
                    MessageBox.Show("not saved");
                }
            }

            sqlConnection.Close();

        }
        private void ShowItem()
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string commandString = @"SELECT * FROM Items";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                itemDataGridView.DataSource = dataTable;
            }
            else
            {
                itemDataGridView.DataSource = null;
                MessageBox.Show("no data found");
            }

        }
        private void DeleteItem()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string commandString = @"DELETE FROM Items WHERE Item= '" + itemComboBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                int isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted == 1)
                {
                    MessageBox.Show(" Successfully deleted");
                }
                else
                {
                    MessageBox.Show("not deleted");
                }

                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void UpdateItem()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string commandString = @"UPDATE Items SET Item= '" + itemComboBox.Text + "',Price='" + priceTextBox.Text + "' WHERE Id=" + idTextBox.Text + " ";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                int isExecuted = sqlCommand.ExecuteNonQuery();

                if (isExecuted == 1)
                {
                    MessageBox.Show(" Successfully updated");
                }
                else
                {
                    MessageBox.Show("not updated");
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void SearchItem()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string commandString = @"SELECT * FROM Items WHERE Item= '" + itemComboBox.Text + "'";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    itemDataGridView.DataSource = dataTable;
                }
                else
                {
                    itemDataGridView.DataSource = null;
                    MessageBox.Show("no data found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /*public bool IsNameExists()
        {

        }*/


        
    }
}
