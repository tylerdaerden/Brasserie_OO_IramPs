using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.People
{
    public class Customer : Person
    {
        #region Attributs

        private CustomerType _type; 

        #endregion


        #region Constructeurs

        public Customer(int id, string lastName, string firstName, bool gender, string email, string phone, CustomerType type)
    : base(id, lastName, firstName, gender, email, phone)
        {
            Type = type;
        }

        #endregion

        #region Propriétés

        /// <summary>
        /// Customer type depending on his restaurant attendance
        /// </summary>
        public CustomerType Type
        {
            get => _type;
            set
            {
                _type = value;
            }
        } 


        // Définir l'énumération pour les catégories de clients
        public enum CustomerType
        {
            New,
            Occasional,
            Regular
        }

        #endregion



        #region Methodes

        /// <summary>
        /// book table, make a reservation instance.
        /// </summary>
        public void BookTable()
        {

        } 

        #endregion


    }
}
