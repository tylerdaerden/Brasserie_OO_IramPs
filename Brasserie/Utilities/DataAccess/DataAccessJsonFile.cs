using Brasserie.Model.Restaurant.Catering;
using Brasserie.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using Brasserie.Utilities.DataAccess.Files;
using Brasserie.Model.Restaurant.Design;
using Brasserie.Model.Restaurant.People;

namespace Brasserie.Utilities.DataAccess
{
    public class DataAccessJsonFile : DataAccess, IDataAccess
    {

        public DataAccessJsonFile(string filePath) : base(filePath)
        {
        }
        public DataAccessJsonFile(string filePath, string[] extensions) : base(filePath, extensions)
        {

        }

        public DataAccessJsonFile(DataFilesManager dfm) :base(dfm)
        {
            
        }
        /// <summary>
        /// retrieve all items object in an ItemCollection from json File Code ITEMS.
        /// </summary>
        /// <returns></returns>
        public override ItemsCollection GetAllItems()
        {

            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("ITEMS");
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                ItemsCollection? its = new ItemsCollection();

                //settings are necessary to get also specific properties of the derivated class
                //and not only common properties of the base class (User)
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                its = JsonConvert.DeserializeObject<ItemsCollection>(jsonFile, settings);
                return its;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }//end GetAllItems

        /// <summary>
        /// update json source file from the item collection
        /// </summary>
        /// <param name="uc"></param>
        public  void UpdateAllItemsDatas(ItemsCollection ic)
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("ITEMS");
            if (IsValidAccessPath)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string json = JsonConvert.SerializeObject(ic, Formatting.Indented, settings);

                File.WriteAllText(AccessPath, json);
            }
            else
            {
                Console.WriteLine("UpdateAllUsersDatas error can't update datasource file");
            }
        }

        /// <summary>
        /// retrieve all tables object in an TablesCollection from json File Code TABLES.
        /// </summary>
        /// <returns></returns>
        public override TablesCollection GetTables()
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("TABLES");
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                TablesCollection? tables = new TablesCollection();

                //settings are necessary to get also specific properties of the derivated class
                //and not only common properties of the base class (User)
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                tables = JsonConvert.DeserializeObject<TablesCollection>(jsonFile, settings);
                return tables;
            }
            else
            {
                //Console.WriteLine("GetTables Failed -> File doesnt exist");
                return null;
            }
        }//end GetTables

        /// <summary>
        /// Retrieve all customers data from json file code CUSTOMERS
        /// </summary>
        /// <returns></returns>
        public override CustomersCollection GetAllCustomers()
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("CUSTOMERS");
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                CustomersCollection customers = new CustomersCollection();

                //settings are necessary to get also specific properties of the derivated class
                //and not only common properties of the base class StaffMember
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                customers = JsonConvert.DeserializeObject<CustomersCollection>(jsonFile, settings);
                return customers;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }

        /// <summary>
        /// update json source file from the customers collection
        /// </summary>
        /// <param name="uc"></param>
        public void UpdateAllCustomers(CustomersCollection customers)
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("CUSTOMERS");
            if (IsValidAccessPath)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string json = JsonConvert.SerializeObject(customers, Formatting.Indented, settings);

                File.WriteAllText(AccessPath, json);
            }
            else
            {
                Console.WriteLine("UpdateAllCustomersDatas error can't update datasource file");
            }
        }

        /// <summary>
        /// update json source file from the customers collection
        /// </summary>
        /// <param name="uc"></param>
        public void UpdateAllStaffMembers(StaffMembersCollection staffMembers)
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("STAFFMEMBERS");
            if (IsValidAccessPath)
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string json = JsonConvert.SerializeObject(staffMembers, Formatting.Indented, settings);

                File.WriteAllText(AccessPath, json);
            }
            else
            {
                Console.WriteLine("UpdateAllCustomersDatas error can't update datasource file");
            }
        }
        /// <summary>
        /// Retrieve all staff members datas from json file code STAFFMEMBERS
        /// </summary>
        /// <returns></returns>
        public override StaffMembersCollection GetAllStaffMembers()
        {
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("STAFFMEMBERS");
            if (IsValidAccessPath)
            {
                string jsonFile = File.ReadAllText(AccessPath);
                StaffMembersCollection staffMembers = new StaffMembersCollection();

                //settings are necessary to get also specific properties of the derivated class
                //and not only common properties of the base class StaffMember
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                staffMembers = JsonConvert.DeserializeObject<StaffMembersCollection>(jsonFile, settings);
                return staffMembers;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }
    }
}
