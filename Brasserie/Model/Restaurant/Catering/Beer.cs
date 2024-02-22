using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Catering
{
    public class Beer : Alcohol
    {
        #region Attributs

        private bool _isAbbeyBeer;
        private bool _isTrappistBeer;

        #endregion


        #region Constructeur
        public Beer(string name, string description, int id, double volume, double percentage, bool isAbbeyBeer , bool isTrappistBeer , double unitPrice, double vatRate, string pictureName) : base(name, description, id, volume, percentage, unitPrice, vatRate, pictureName)
        {
            IsAbbeyBeer = isAbbeyBeer ;
            IsTrappistBeer = isTrappistBeer ;
        }
        #endregion

        #region Props

        public bool IsAbbeyBeer { get => _isAbbeyBeer; set => _isAbbeyBeer = value ; }

        public bool IsTrappistBeer { get => _isTrappistBeer; set => _isTrappistBeer = value ; }

        #endregion


    }
}
