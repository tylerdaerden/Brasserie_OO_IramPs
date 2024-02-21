using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Catering
{
    class Alcohol : Drink
    {
        //Constantes
        const double MAX_ALC = 100.00;
        const double NA_ALC = 0.0;
             
        private double _percentage;
        private bool _isNA;


        #region Constructeur
        public Alcohol(string name, string description, int id, double volume, double percentage , bool isna , double unitPrice, double vatRate, string pictureName) : base(name, description, id, volume, unitPrice, vatRate, pictureName)
        {

            Percentage = percentage;
            IsNa = isna;
        }

        #endregion


        #region Props

        public double Percentage
        {
            get => _percentage;
            set
            {
                if(CheckAlcMaxPercentage(value))
                {
                    _percentage = value;
                }

            }
        }

        public bool IsNa { get => _isNA; set => _isNA = value; }

        #endregion

        #region Méthode Vérifications

        private bool CheckAlcMaxPercentage(double percentage )
        {
            return _percentage <= MAX_ALC;
        }

        #endregion


        #region Méthodes

        public bool EvalNA(double percentage)
        {
            if (percentage != NA_ALC) 
            {                
                return IsNa = false;
            }
            
            return IsNa = true;
        }

        #endregion

    }
}
