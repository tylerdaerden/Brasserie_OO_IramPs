using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Catering
{
    public class Aperitif : Alcohol
    {
        #region Attributs


        #endregion


        #region Constructeur
        public Aperitif(int id, string name, string description, double unitPrice, string pictureName, double vatRate, double volume, double percentage) : base(id, name, description, unitPrice, pictureName, vatRate, volume, percentage)
        {
        }

        #endregion



        #region Props


        #endregion



        #region Methodes


        #endregion

    }
}
