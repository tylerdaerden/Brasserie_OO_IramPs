using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Catering
{
    public class Dish : Item
    {

        #region Attributs


        #endregion


        #region Constructeurs

        public Dish(int id, string name, string description, double unitPrice, string pictureName, double vatRate) : base(id, name, description, unitPrice, pictureName, vatRate)
        {
        }

        #endregion

        #region Props

        #endregion


        #region Methodes 

        /// <summary>
        /// Auto Description for this Dish
        /// </summary>
        public override string AutoDescription()
        {
            return $"{Name} - {Description} au prix de {UnitPrice}";
        }

        #endregion

    }
}
