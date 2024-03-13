using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Catering
{
    public class Drink : Item
    {
        #region Attributs

        //constantes
        const double MIN_VOL = 1.0;

        private double _volume;

        #endregion



        #region Constructeurs
        public Drink(int id, string name, string description, double unitPrice, string pictureName, double vatRate, double volume)
            : base(id, name, description, unitPrice, pictureName, vatRate)
        {
            Volume = volume;
        }

        #endregion


        #region Props

        public double Volume
        {
            get => _volume;
            set
            {
                if(CheckDrinkVolume(value))
                {
                    _volume = value;
                }

            }
        }

        #endregion

        #region Méthode Vérifications

        private static bool CheckDrinkVolume(double volume)
        {
            return volume >= MIN_VOL;
        }

        #endregion




    }
}
