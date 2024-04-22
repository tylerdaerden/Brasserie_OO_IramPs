using Brasserie.Model.Restaurant.People;
using Brasserie.Utilities.Interfaces;
using Brasserie.View;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.ViewModel
{
    public partial class StaffMembersPageViewModel : BaseViewModel
    {
        public StaffMembersPageViewModel(IDataAccess dataAccessService, IAlertService alertService) : base(alertService)
        {
            dataAccess = dataAccessService;
            StaffMembers = dataAccess.GetAllStaffMembers(); //get user's collection datas from chosen DataAccessSource (excel, csv, json...).                                             
        }

        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IDataAccess dataAccess;

        /// <summary>
        /// collection of all StaffMembers
        /// </summary>
        public StaffMembersCollection StaffMembers { get; set; }

        /// <summary>
        /// Staff Member selected in the listview
        /// </summary>
        [ObservableProperty]
        private StaffMember staffMemberSelection;

        /// <summary>
        /// Staff Member who will be displayed in the popup screen
        /// </summary>
        [ObservableProperty]
        private StaffMember staffMemberPopupDisplayed;

        /// <summary>
        /// flag to know if user want to add a new staff member or consulting an existing one.
        /// </summary>
        [ObservableProperty]
        private bool isNewMemberAction;

        /// <summary>
        /// Save changes, add, delete staffMemebers datas to the source.
        /// </summary>
        [RelayCommand()]
        public void SaveDatas()
        {
            if (dataAccess.UpdateAllStaffMembers(StaffMembers))
            {
                alertService.ShowAlert("Sauvegarde", "Les données staff members ont bien été sauvegardées");
            }
            else
            {
                alertService.ShowAlert("Sauvegarde erreur", "Une erreur est survenue lors de la sauvegarde");
            };
        }

        /// <summary>
        /// Show popup for a new staffMember edition
        /// command binded to the "Add new member" in the StaffMembersPage, will open the popup screen
        /// </summary>
        [RelayCommand()]
        public void ShowNewStaffMemberPopup()
        {
            //store information to know we will display the "Add New Member" button on the popup display
            IsNewMemberAction = true;
            //get an id for the new StaffMember
            int nextId = StaffMembers.GetNextId();
            //create a blank StaffMember
            StaffMemberPopupDisplayed = new StaffMember(nextId, "Nom", "Prenom", true, "youremail@gmail.com", "0470000000", "BE00 0000 0000 0000", "1, rue 1000 Ville", 0.0);
            //create an instance of the NewStaffMemberPopup and give this viewModel
            var popup = new NewStaffMemberPopup(this);
            //show the popup on screen
            Shell.Current.CurrentPage.ShowPopup(popup);
        }

        /// <summary>
        /// Command binded to the "Add new Member" button in the pop up display
        /// </summary>
        [RelayCommand()]
        public void AddNewStaffMember()
        {
            if (StaffMembers.AddStaffMember(StaffMemberPopupDisplayed))
            {
                alertService.ShowAlert("Ajout", "Le nouveau membre a bien été ajouté");
            }
            else
            {
                alertService.ShowAlert("Ajout erreur", "Une erreur est survenue lors de l'ajout");
            };
            //reset the property for a future choice.
            IsNewMemberAction = false;
        }

        /// <summary>
        /// Get selection event from the listView
        /// Show popup for an existing staffMember read and edition
        /// </summary>
        [RelayCommand()]
        private void SelectStaffMember(StaffMember sm)
        {
            //prevent to display "Add New Member button" on the popup display because it's an existing one
            IsNewMemberAction = false;
            //affect the StaffMemberPopupDisplayed property to this current staffMember selected.
            StaffMemberPopupDisplayed = sm;
            //create an instance of the NewStaffMemberPopup and give this viewModel
            var popup = new NewStaffMemberPopup(this);
            //show the popup on screen
            Shell.Current.CurrentPage.ShowPopup(popup);
        }

    }//end class

}