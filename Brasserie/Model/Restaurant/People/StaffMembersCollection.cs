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
        /// Add staff member to the collection if not already a similar id or (firstName and LastName) in this collection
        /// </summary>
        /// <param name="c"></param>
        public bool AddStaffMember(StaffMember sm)
        {
            if (this.Count == 0 || !this.Any(staffMemberInTheCollection => staffMemberInTheCollection.Id == sm.Id || (staffMemberInTheCollection.LastName == sm.LastName && staffMemberInTheCollection.FirstName == sm.FirstName)))
            {
                this.Add(sm);
                return true;
            }
            else
            {
                //id staff member or staff member LastName & FirstName already in the collection and will not be added.
                return false;
            }
        }


        /// <summary>
        /// Removal of a staff Member to the collection if  already a similar id or (firstName and LastName) in this collection
        /// </summary>
        /// <param name="sm"></param>
        /// <returns></returns>
        public bool RemoveStaffMember(StaffMember sm) //on peut remplacer bool par string et gérer messages erreurs selon cas , later ! pour gérer cas de selection nulle.
        {
            if ( this.Count!=0 && sm != null && this.Any(staffMemberInTheCollection => staffMemberInTheCollection.Id == sm.Id ))
            {
                this.Remove(sm);
                return true;

            }
            else
            {
                //if StaffMember not in the collection 
                return false;
            }

        }


        /// <summary>
        /// Determine new next id (max + 1) for a manual AddItem
        /// </summary>
        /// <returns></returns>
        public int GetNextId()
        {
            if (this != null && this.Count > 1)
            {
                return this.Max(sm => sm.Id) + 1;
            }
            else
            {
                return 1;
            }
        }
    }


    #endregion



}

