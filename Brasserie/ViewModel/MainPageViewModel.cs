using Brasserie.Model.Restaurant.Catering;
using Brasserie.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.ViewModel
{
    public class MainPageViewModel
    {

        public MainPageViewModel(IDataAccess dataAccessService) : base()
        {

            dataAccess = dataAccessService;

            Items = dataAccess.GetAllItems(); //get user's collection datas from chosen DataAccessSource (excel, csv, json...).
                                              //Tables = DataAccess.GetTables(); //get table's collection datas from chosen DataAccessSource (excel, csv, json...).


        }


        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IDataAccess dataAccess;

        /// <summary>
        /// Collection of all users in the databse (source file)
        /// </summary>
        public ItemsCollection Items { get; set; }

        /// <summary>
        /// Désigne l'élement sélectionné dans la liste
        /// </summary>
        public Item ItemSelected { get; set; }



    }
}
