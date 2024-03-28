using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.People
{
    public class StaffMembersCollection : ObservableCollection<StaffMember>
    {


        public StaffMembersCollection() { }


        #region Methodes


        /// <summary>
        /// Add StaffMember 
        /// </summary>
        /// <param name="sm"></param>
        public void AddStaffmember(StaffMember sm)
        {
            if (this.Count == 0 || !this.Any(StaffMemberInTheCollection => StaffMemberInTheCollection.Id == sm.Id || (StaffMemberInTheCollection.LastName == sm.LastName && StaffMemberInTheCollection.FirstName == sm.FirstName)))
            {
                this.Add(sm);
            }
            else
            {
                //id StaffMember or StaffMember LastName & FirstName already in the collection and will not be added.
            }

        } 


        #endregion



    }
}
