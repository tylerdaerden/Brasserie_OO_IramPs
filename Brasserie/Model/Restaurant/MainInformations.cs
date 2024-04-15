using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class MainInformations : INotifyPropertyChanged
{
    /// <summary>
    /// implémentation de l'interfaceINotifyPropertyChanged ↓↓↓
    /// </summary>
  public event PropertyChangedEventHandler? PropertyChanged;


    #region Attributs

    private string _name = "";
    private string _address = "";
    private string _vatCode = "";
    private string _webSite = "";  

    #endregion


    #region Constructeur

    public MainInformations(string name, string address, string vatCode, string
webSite)
    {
        _name = name;
        _address = address;
        _vatCode = vatCode;
        _webSite = webSite;
    }

    #endregion


    #region Props

    /// <summary>
    /// Restaurant's name
    /// </summary>
    public string Name
    {
        get => _name;
        set
        {
            if (CheckRestaurantName(value))
            {
                _name = value;
            }

            OnPropertyChanged(nameof(Name));
        }
    }

    /// <summary>
    /// Restaurant's Postal Address
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

            OnPropertyChanged(nameof(Address));
        }
    }
    /// <summary>
    /// Vat balgian company code
    /// </summary>
    public string VatCode
    {
        get => _vatCode;
        set
        {
            if (CheckBelgianVatCode(value))
            {
                _vatCode = value;
            }

            OnPropertyChanged(nameof(VatCode));
        }
    }
    /// <summary>
    /// url restaurant's website
    /// </summary>
    public string WebSite
    {
        get => _webSite;
        set
        {
            if (CheckUrl(value))
            {
                _webSite = value;
            }

            OnPropertyChanged(nameof(WebSite));
        }
    }
    #endregion

    #region CheckMethods

    /// <summary>
    /// Vat Code number for belgian company BE 0563.191.043
    /// </summary>
    /// <param name="tryAccount"></param>
    /// <returns></returns>
    public static bool CheckBelgianVatCode(string tryCode)
    {
        if (!string.IsNullOrEmpty(tryCode))
        {
            if (!Regex.IsMatch(tryCode, @"^BE\s?\d{4}\.\d{3}\.\d{3}$"))
            {
                //MessageBox.Show($"La saisie {trytryCode} ne correpond pas au format
                //", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// Check Name must be at least one char.
    /// </summary>
    /// <param name="tryAccount"></param>
    /// <returns></returns>
    public static bool CheckRestaurantName(string tryName)
    {
        if (!string.IsNullOrEmpty(tryName))
        {
            if (tryName.Length >= 1)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Vat Code number for belgian company Ex: BE 0563.191.043
    /// </summary>
    /// <param name="tryUrl"></param>
    /// <returns></returns>
    public static bool CheckUrl(string tryUrl)
    {
        if (!string.IsNullOrEmpty(tryUrl))
        {
            if (!Regex.IsMatch(tryUrl, @"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][azA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.
            [a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})"))
            {
                return false;
            }
            return true;
        }
        //MessageBox.Show($"La saisie {tryUrl} ne correpond pas au format ", "Erreur
        //de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
        return false;
    }
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
            if (!Regex.IsMatch(tryAddress, @"^[0-9]{1,}[a-zA-Z]?, [a-zA-Zéèêà ]{1,}[0-9]{2,} [a-zA-Zéèêà() ]{1,}$"))
            {
                //MessageBox.Show($"La saisie {tryAddress} ne correpond pas au format
                //[N°] (A, B, ...), [nom de rue][code postal][Ville(Pays)] ", "Erreur de saisie",
                //MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }
        return false;
    }

    #endregion

    #region Méthodes

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    } 

    #endregion



}//end class


