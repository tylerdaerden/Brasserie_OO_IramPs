using Brasserie.Model.Restaurant.Catering;
using Brasserie.Model.Restaurant.Design;
using Brasserie.Model.Restaurant.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Utilities.Interfaces
{
    public interface IDataAccess
    {
        /// <summary>
        /// Access string to the external source (file path, connection string ...)
        /// </summary>
        string AccessPath
        {
            get;
            set;
        }
        /// <summary>
        /// retrieve items informations from the external source
        /// </summary>
        /// <returns>an ItemsCollection </returns>
        ItemsCollection GetAllItems();
        /// <summary>
        /// retrieve tables informations (Id numbers and seats number) from the external source
        /// </summary>
        /// <returns>an TablesCollection</returns>
        TablesCollection GetTables();
        /// <summary>
        /// retrieve customers informations from the external source
        /// </summary>
        /// <returns>a CustomersCollection </returns>
        CustomersCollection GetAllCustomers();
        /// <summary>
        /// retrieve staff members informations from the external source
        /// </summary>
        /// <returns>a StaffMembersCollection </returns>
        StaffMembersCollection GetAllStaffMembers();
        //All CRUD methods must be added here

        /// <summary>
        /// update source from the actual StaffMembersCollection
        /// </summary>
        /// <param name="staffMembers"></param>
        /// <returns></returns>
        bool UpdateAllStaffMembers(StaffMembersCollection staffMembers);


    }
}
