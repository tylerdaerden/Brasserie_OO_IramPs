using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace Brasse.Model.Restaurant.Design
{
    public class Table
    {
        #region Attributs

        const int MIN_SEATS = 2;
        const int MIN_ID = 1;
        //Champs de classe 
        private int _seatsNumber; //>=2
        private int _idNumber;
        private bool _isNowBusy;
        //Champs static
        private static int _totalSeats;

        #endregion


        #region Constructeurs 

        public Table(int seatsNumber, int idNumber, bool isNowBusy)
        {
            SeatsNumber = seatsNumber;
            IdNumber = idNumber;
            IsNowBusy = isNowBusy;
            TotalSeats += SeatsNumber;
        } 

        #endregion


        #region Propriétés

        /// <summary> 
        /// Seats Number
        /// </summary> 
        public int SeatsNumber
        {
            get => _seatsNumber;
            set
            {
                if (CheckSeatsNumber(value))
                {
                    _seatsNumber = value;
                }
            }
        }
        /// <summary> 
        /// id Number
        /// </summary>
        public int IdNumber
        {
            get => _idNumber;
            set
            {
                if (CheckIdNumber(value))
                {
                    _idNumber = value;
                }
            }
        }
        /// <summary> 
        /// isNowBusy
        /// </summary>
        public bool IsNowBusy { get => _isNowBusy; set => _isNowBusy = value; }

        /// <summary>
        /// Totalisateur d'instance de Seats
        /// </summary>
        public static int TotalSeats
        {
            get => _totalSeats; private set => _totalSeats = value;
        } 

        #endregion


        #region Méthodes de vérifications
        /// <summary>
        /// Vérification du nombre de Siege supérieur à MIN_Seats
        /// </summary>
        private bool CheckSeatsNumber(int seatsNumber)
        {
            return seatsNumber >= MIN_SEATS;
        }

        /// <summary>
        /// Check de l'id
        /// </summary>
        private bool CheckIdNumber(int idNumber)
        {
            return idNumber >= MIN_ID;
        } 
        #endregion

    }
}