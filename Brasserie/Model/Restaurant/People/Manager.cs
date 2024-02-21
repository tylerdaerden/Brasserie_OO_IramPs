using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.People
{
    public class Manager : StaffMember
    {

        //déclaration des constantes
        protected const string DEFAULT_PASSWD = "Password01"; //password par défaut

        #region Attributs

        private static int MIN_CHAR_PASSWORD = 8;
        private static int MAX_CHAR_PASSWORD = 20;
        private static int KEY_HASH_PASSWORD = 5;
        private static int NBR_CHAR_LASTNAME = 6;  //number of chars in the lastname
        private static int NBR_CHAR_FIRSTNAME = 1; //number of chars in the fistname
        private static double BONUS_RATE = 0.05;
        private string _login;
        private string _password;

        #endregion


        #region Constructeurs

        public Manager(int id, string lastName, string firstName, bool gender, string email, string phone, string bankAccount, string address, double salary, string password)
              : base(id, lastName, firstName, gender, email, phone, bankAccount, address, salary)
        {
            BuildLogin();
            Password = password;
        }

        public Manager() : base()
        {

        }

        #endregion

        #region Props

        /// <summary>
        /// Personal auto builded login
        /// </summary>
        public string Login
        {
            get
            {
                return _login;
            }
            private set
            {
                _login = value;
            }
        }
        /// <summary>
        /// Personnal password with rules
        /// </summary>
        protected string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (CheckPassword(value, this.FirstName, this.LastName))
                    _password = value;
            }
        }

        #endregion

        #region Methode Verifications

        /// <summary>
        /// Password must contains at least a figure 0 to 9, at least one uppercase, only alphanumeric characters not éèàâê 
        ///without spaces, at least 8 characters maximum 20. Must not contains firstname, lastname (ingoring case). 
        /// </summary>
        /// <param name="password">try password to check</param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>true if valid password</returns>

        public static bool CheckPassword(string password, string firstName, string lastName)
        {


            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                if (password.ToLower().Contains(firstName.ToLower()) ||
                    password.ToLower().Contains(lastName.ToLower()))
                {
                    //MessageBox.Show("Le mot de passe ne peut comporter ni votre nom ni votre prénom",
                    //              "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }
            if (password.Length < MIN_CHAR_PASSWORD)
            {
                //MessageBox.Show("Le mot de passe doit comporter au moins " + MIN_CHAR_PASSWORD + " caractères", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (password.Length > MAX_CHAR_PASSWORD)
            {
                //MessageBox.Show("Le mot de passe doit comporter maximum " + MAX_CHAR_PASSWORD + " caractères", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            //test s'il y a présence de caractères spéciaux (en dehors de l'alphabet) ou accentués 
            //test si chaque caractère du début à la fin est dans l'intervalle a-z ou A-Z ascii
            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]*$"))
            {
                //MessageBox.Show($"Le mot de passe ne peut comporter que des lettres de l'alphabet non accentuées", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            //test s'il y a présence d'au moins un chiffre nimporte où dans le mot
            //dans ce cas il faut enlevent ^ * sinon cela voudrait dire est ce que tous les caractères du début à la fin sont des chiffres.
            if (!Regex.IsMatch(password, @"[0-9]+"))
            {
                //MessageBox.Show($"Le mot de passe doit comporter au moins un chiffre.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            if (!Regex.IsMatch(password, @"[A-Z]+"))  //if (!Regex.IsMatch(password, @"^(?=.*[A-Z]).+$"))
            {
                //MessageBox.Show($"Le mot de passe doit comporter au moins une majuscule.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        } //end CheckPassword 

        #endregion


        #region Methode de Classe

        /// <summary>
        /// Try to change password with a new one. Old password must be entered
        /// </summary>
        /// <param name="oldPassword">actual old password</param>
        /// <param name="newPassword">"new password tried</param>
        /// <param name="confirmNewPassword">"repeat new password to confirm</param>
        /// <returns></returns>
        public bool ChangePassword(string oldPassword, string newPassword, string confirmNewPassword)
        {

            if (IsRightPassword(oldPassword))//match old password input and actual Password
            {
                if (newPassword.Equals(confirmNewPassword))
                {
                    Password = newPassword; //attempt to modify property
                    return newPassword.Equals(Password); //if attempt is successful, Password and newPassword are equals.
                }
                else
                {
                    //MessageBox.Show($"Le nouveau mot de passe et sa confirmation ne correspondent pas",
                    // "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
            }
            else
            {
                //MessageBox.Show($"L'ancien mot de passe ne correspond pas.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }
        /// <summary>
        /// Check if the entry password is the right password for this user
        /// </summary>
        /// <param name="tryPassword"></param>
        /// <returns>true if password is correct</returns>
        public bool IsRightPassword(string tryPassword)
        {
            return tryPassword.Equals(this.Password);
        }

        /// <summary>
        /// hash Password for sending a encrypted password 
        /// </summary>
        /// <returns>hashed password</returns>
        public string SendHashPassword()
        {
            string hashPassword = string.Empty;

            if (string.IsNullOrEmpty(Password))
            {
                Password = DEFAULT_PASSWD;
            }
            char[] charArrayPassword = Password.ToCharArray();
            for (int i = charArrayPassword.Length - 1; i >= 0; i--)
            {
                hashPassword += (char)((int)(charArrayPassword[i]) + KEY_HASH_PASSWORD);
            }

            return hashPassword;

        }

        public static string GetHashPassword(string hashPassword)
        {

            string password = string.Empty;
            char[] charArrayHashPassword = hashPassword.ToCharArray();
            for (int i = charArrayHashPassword.Length - 1; i >= 0; i--)
            {
                password += (char)((int)(charArrayHashPassword[i]) - KEY_HASH_PASSWORD);
            }
            return password;
        }

        /// <summary>
        /// Build Login property from FirstName and LastName : 6 char from Lastname + First char of firstname
        /// </summary>
        private void BuildLogin()
        {
            //only if firstname et lastname are filled.  
            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
            {
                //to build login, ' ' and '-' perhaps in the fisrtname or lastname are deleted
                string firstNameToUse = Regex.Replace(FirstName, "[ -]", string.Empty);
                string lastNameToUse = Regex.Replace(LastName, "[ -]", string.Empty);
                //only 6 firts chars if lastname lenght is longer 
                if (lastNameToUse.Length >= NBR_CHAR_LASTNAME)
                {
                    this.Login = lastNameToUse.Substring(0, NBR_CHAR_LASTNAME) +
                             firstNameToUse.Substring(0, NBR_CHAR_FIRSTNAME);//renvoie les 6 premiers
                }
                else
                {//if lastname's lenght is lesser than 6 all chars are taken 
                    this.Login = lastNameToUse + firstNameToUse.Substring(0, NBR_CHAR_FIRSTNAME);
                }

            }
        }//end BuildLogin()

        /// <summary>
        /// compute salary bonus RATE * Salary -> ex 5% of 4500€ = 0.05*4500€
        /// </summary>
        /// <returns></returns>
        private double ComputeBonus()
        {
            return BONUS_RATE * Salary;
        } 

        #endregion

    }
}
