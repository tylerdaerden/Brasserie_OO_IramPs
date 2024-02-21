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
        public Drink(string name, string description, int id, double volume , double unitPrice, double vatRate, string pictureName) : base(name, description, id, unitPrice, vatRate, pictureName)
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

        private bool CheckDrinkVolume(double volume)
        {
            return volume >= MIN_VOL;
        }

        #endregion




    }
}
