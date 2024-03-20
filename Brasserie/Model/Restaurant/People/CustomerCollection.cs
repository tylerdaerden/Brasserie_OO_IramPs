using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.People
{
    public class CustomerCollection : ObservableCollection<Customer>
    {
        public CustomerCollection() { }

        /// <summary>
        /// Add new Customer in the collection checking  if this item isn't already inside checking by the Id and the Name
        /// </summary>
        /// <param name="customer"></param>

        public new void AddCustomer(Customer customer)
        {
            if(!this.Any(CustomerInCollection => CustomerInCollection.Id == customer.Id || CustomerInCollection.FirstName == customer.FirstName|| CustomerInCollection.LastName == customer.LastName))
            {
                this.Add(customer);
            }
            else 
            {
                //if already in collection , not added
            }

        }




    }
}
