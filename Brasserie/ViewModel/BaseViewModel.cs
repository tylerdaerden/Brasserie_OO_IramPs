using Brasserie.Utilities.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        public BaseViewModel(IAlertService alertService, string restaurantName = "My restaurant")
        {
            RestaurantName = restaurantName;
            this.alertService = alertService;
            MainInfos = new MainInformations("My Restaurant", "4, rue de la Lys 7000 Mons", "BE 0563.191.043", "http://myrestaurant.be");
        }

        public MainInformations MainInfos { get; set; }

        protected IAlertService alertService;
        public string RestaurantName { get; set; } = "Le Passe Temps";
        public DateTime Today { get; } = DateTime.Now;
        public string TodayDate => Today.Date.ToString("d-M-yyyy");
    }
}
