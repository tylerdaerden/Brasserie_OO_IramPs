using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Catering
{
    public class Alcohol : Drink
    {
        //Constantes
        const double MAX_ALC = 100.00;
        const double MIN_ALC = 0.01;
        // pas de constantes sur ce projet pour le NA mais pourrais dans d'autres
        //const double NA_ALC = 0.0;

        private double _percentage;
        private bool _isNA;


        #region Constructeur
        public Alcohol(string name, string description, int id, double volume, double percentage, double unitPrice, double vatRate, string pictureName) : base(name, description, id, volume, unitPrice, vatRate, pictureName)
        {
            Percentage = percentage;
            EvalNA();
        }

        #endregion


        #region Props

        public double Percentage
        {
            get => _percentage;
            set
            {
                if (CheckDegreePercentage(value))
                {
                    _percentage = value;
                    //afin de s'assurer une vérification si le pourcentage d'alcool venait à être modifié ! 
                    EvalNA();
                }

            }
        }

        public bool IsNa
        {
            get => _isNA;
            set
            {                
                {
                    _isNA = value;
                }
            }
        }

        #endregion

        #region Méthode Vérifications

        /// <summary>
        /// Check Alcohol degree percentage btw MIN and MAX CONST
        /// </summary>
        /// <param name="percentage"></param>
        /// <returns></returns>
        private static bool CheckDegreePercentage(double percentage)
        {
            return (percentage >= MIN_ALC && percentage <= MAX_ALC);
        }

        #endregion


        #region Méthodes

        /// <summary>
        /// procedure de NA or NOT en fonction du degrée d'alcool
        /// </summary>
        private void EvalNA()
        {
            IsNa = Percentage == 0;
        }

        #endregion

    }
}
