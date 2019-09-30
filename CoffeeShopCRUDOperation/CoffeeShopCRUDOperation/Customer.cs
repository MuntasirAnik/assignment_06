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
using CoffeeShopCRUDOperation.BLL;

namespace CoffeeShopCRUDOperation
{
    public partial class Customer : Form
    {
        CustomerManager _customerManager = new CustomerManager(); 
       // string connectionString=  @"Server= DESKTOP-LE66CE0; Database= CoffeeShop_07; Integrated Security=True";
        

        public Customer()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "" || contactTextBox.Text == "" || addressTextBox.Text == "")
            {
                MessageBox.Show("enter your info");
            }
            else
            {
                if (_customerManager.IsNameExists(nameTextBox.Text))
                {
                    MessageBox.Show(nameTextBox.Text + " Already Exists");
                    return;
                }
                bool isAdded = _customerManager.AddCustomers(nameTextBox.Text, contactTextBox.Text, addressTextBox.Text);

                if (isAdded)
                {
                    MessageBox.Show("data Saved successfully");
                }
                else
                {
                    MessageBox.Show("not saved");
                }
            }
            

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            customerDataGridView.DataSource = _customerManager.ShowCustomer();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(_customerManager.DeleteCustomer(nameTextBox.Text))
            {
                MessageBox.Show("successfully deleted");
            }
            else
            {
                MessageBox.Show("not deleted");
            }
            customerDataGridView.DataSource = _customerManager.ShowCustomer();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text=="" || contactTextBox.Text==""||addressTextBox.Text=="")
            {
                MessageBox.Show("enter your update value");
            }
            else
            {
                if (_customerManager.UpdateCustomer(nameTextBox.Text, contactTextBox.Text, addressTextBox.Text, idTextBox.Text))
                {
                    MessageBox.Show("Successfylly Updated");
                }
                else
                {
                    MessageBox.Show("not Updated");
                }
            }
            
            customerDataGridView.DataSource = _customerManager.ShowCustomer();
        }

        private void serachButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text=="")
            {
                MessageBox.Show("enter search name");
            }
            else 
            {
                customerDataGridView.DataSource = _customerManager.SearchCustomer(nameTextBox.Text);
            }
            
                  
        }


        
        
        
        
        
        

    }
}
