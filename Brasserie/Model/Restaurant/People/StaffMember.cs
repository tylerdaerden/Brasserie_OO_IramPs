using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.People
{
    /// <summary>
    /// This class concern general staff member employee who receives a salary 
    /// </summary>
    public class StaffMember : Person
    {
        #region Attributs

        private string _bankAccount;
        private string _address;
        private double _salary;

        #endregion

        #region Constructeurs

        public StaffMember(int id, string lastName, string firstName, bool gender, string email, string phone, string bankAccount, string address, double salary) : base(id, lastName, firstName, gender, email, phone)
        {
            BankAccount = bankAccount;
            Address = address;
            Salary = salary;
        }

        public StaffMember() : base()
        {

        }

        #endregion

        #region Props

        /// <summary>
        /// Belgian Bank Account (the owner requires his employees to have a bank account in Belgium)
        /// </summary>
        public string BankAccount
        {
            get => _bankAccount;
            set
            {
                if (CheckBelgianAccount(value))
                {
                    _bankAccount = value;
                }
            }
        }

        /// <summary>
        /// Personal address format : "[N°](A,B,...), [street's name] [ZIP ode] [City (Country)]"
        /// </summary>
        public string Address
        {
            get => _address;
            set
            {
                if (CheckAddress(value))
                {
                    _address = value;
                }
            }
        }

        /// <summary>
        /// staff member gross salary
        /// </summary>
        protected double Salary
        {
            get => _salary;
            set
            {
                if (CheckSalary(value))
                {
                    _salary = value;
                }
            }
        }

        #endregion

        #region Methodes

        /// <summary>
        /// staff member ask a leave for a period of time
        /// </summary>
        public void LeaveRequest()
        {

        }

        /// <summary>
        /// For Staff Member wage calculation is very simple → return Salary . 
        /// </summary>
        /// <returns></returns>
        public virtual double WageCalculation()
        {
            return Salary;
        }

        /// <summary>
        /// get main informations of this staff member
        /// </summary>
        public string GetMainInformations()
        {
            return $"{FirstName} {LastName} Mobile : {MobilePhoneNumber} Address : {Address}";
        }

        #endregion


        #region Methodes Verifications

        /// <summary>
        ///Check address format typical "23, rue de la bénédiction 7000 Mons"
        ///"[N°](A,B,...), [nom de rue] [code postal] [Ville (Pays)]"
        /// </summary>
        /// <param name="tryAddress"></param>
        /// <returns></returns>
        public static bool CheckAddress(string tryAddress)
        {
            if (!string.IsNullOrEmpty(tryAddress))
            {
                if (!Regex.IsMatch(tryAddress, @"^[0-9]{1,}[a-zA-Z]?, [a-zA-Zéèêà ]{1,} [0-9]{2,} [a-zA-Zéèêà() ]{1,}$"))
                {
                    //MessageBox.Show($"La saisie {tryAddress} ne correpond pas au format [N°](A,B,...), [nom de rue] [code postal] [Ville (Pays)]", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// account number for belgian bank BEXX XXXX XXXX XXXX
        /// </summary>
        /// <param name="tryAccount"></param>
        /// <returns></returns>
        public static bool CheckBelgianAccount(string tryAccount)
        {
            if (!string.IsNullOrEmpty(tryAccount))
            {
                if (!Regex.IsMatch(tryAccount, @"^BE[0-9]{2} [0-9]{4} [0-9]{4} [0-9]{4}$"))
                {
                    //MessageBox.Show($"La saisie {tryAccount} ne correpond pas au format BEXX XXXX XXXX XXXX", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check validity of salary
        /// </summary>
        /// <param name="trySalary"></param>
        /// <returns></returns>
        private bool CheckSalary(double trySalary)
        {
            return trySalary > 0;
        } 

        #endregion
    }
}
