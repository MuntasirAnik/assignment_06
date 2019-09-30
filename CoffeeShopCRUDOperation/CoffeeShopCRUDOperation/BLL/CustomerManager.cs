using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopCRUDOperation.Repository;

namespace CoffeeShopCRUDOperation.BLL
{
    public class CustomerManager
    {

        CustomerRepository _customerRepository = new CustomerRepository();

        public bool AddCustomers(string name, string contact, string address)
        {
            return _customerRepository.AddCustomer(name, contact, address);

        }

        public bool IsNameExists(string name)
        {
            return _customerRepository.IsNameExists(name);

        }

        public bool DeleteCustomer(string name)
        {
            return _customerRepository.DeleteCustomers(name);
        }
        public bool UpdateCustomer(string name, string contact, string address, string id)
        {
            return _customerRepository.UpdateCustomer(name, contact, address, id);
        }
        public DataTable ShowCustomer()
        {
            return _customerRepository.ShowCustomer();
        }
        public DataTable SearchCustomer(string name)
        {
            
            return _customerRepository.SearchCustomer(name);
        }
    }
}
