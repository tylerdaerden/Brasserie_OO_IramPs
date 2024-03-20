using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.People
{
    public class CustomersCollection : ObservableCollection<Customer>
    {

        public CustomersCollection() { }

        /// <summary>
        /// Add customer to the collection
        /// </summary>
        /// <param name="c"></param>
        public void AddCustomer(Customer c)
        {
            if (this.Count == 0 || !this.Any(CustomerInTheCollection => CustomerInTheCollection.Id == c.Id || (CustomerInTheCollection.LastName == c.LastName && CustomerInTheCollection.FirstName == c.FirstName)))
            {
                this.Add(c);
            }
            else
            {
                //id customer or customer LastName & FirstName already in the collection and will not be added.
            }
        }

        /// <summary>
        /// New customers percentage of all customers
        /// </summary>
        public double NewCustomersPercentage => ComputeTypePercentage(Customer.CustomerType.New);

        /// <summary>
        /// Occasional customers percentage of all customers
        /// </summary>
        public double OccasionalCustomersPercentage => ComputeTypePercentage(Customer.CustomerType.Occasional);

        /// <summary>
        /// Regular customers percentage of all customers
        /// </summary>
        public double RegularCustomersPercentage => ComputeTypePercentage(Customer.CustomerType.Regular);

        /// <summary>
        /// Compute percentage of a cutomer's type 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public double ComputeTypePercentage(Customer.CustomerType type)
        {   //this.Count -> total customers number
            int countType = this.Count(c => c.Type == type);//numbers of customers of searched type

            return Count != 0 ? 100.0 * ((double)countType / Count) : 0.0;

        }

        /// <summary>
        /// send email to all customers
        /// </summary>
        public void SendPromotionalEmail()
        {
            //not implemented  voir OAuth 2.0 pour l'autorisation  à un compte gmail.
        }

    }//end CustomersCollection Class

}

