using Brasse.Model.Restaurant.Design;
using Brasserie.Model.Restaurant.Catering;
using Brasserie.Model.Restaurant.Design;
using Brasserie.Model.Restaurant.People;
using Brasserie.Utilities.DataAccess.Files;
using Brasserie.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Utilities.DataAccess
{
    public class DataAccessCsvFile : DataAccess , IDataAccess
    {

        public DataAccessCsvFile(string filePath) : base(filePath)
        {
        }
        /// <summary>
        /// Constructor associated with a datafileManager, it contains path to a config text file
        /// wich contains path to csv files
        /// </summary>
        /// <param name="dfm"></param>
        public DataAccessCsvFile(DataFilesManager dfm) : base(dfm) { }

        public override ItemsCollection GetAllItems()
        {
            List<string> listToRead = new List<string>();
            ItemsCollection items = new ItemsCollection();
            string temp = DataFilesManager.DataFiles.GetFilePathByCodeFunction("ITEMS");
            AccessPath = temp;
            if (IsValidAccessPath)
            {
                listToRead = System.IO.File.ReadAllLines(AccessPath).ToList();
                //remove first title line
                listToRead.RemoveAt(0);
                foreach (string s in listToRead)
                {
                    Item it = GetItem(s);
                    items.AddItem(it);
                }
                return items;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }//end GetAllItems
        /// <summary>
        /// Split a line like : BEER;21;Bush Ambrée 25;bière brassée sur place;4.50;bush_ambree25.jpg;21.00;25;10.5;false;false
        /// and create instance with each fields.
        /// First Field contain type (DISH, APERITIF, SOFT, BEER)
        /// </summary>
        /// <param name="csvline"></param>
        /// <returns></returns>
        private static Item GetItem(string csvline)
        {
            string[] fields = csvline.Split(';');
            switch (fields[0])
            {
                case "DISH":
                    return new Dish(id: int.Parse(fields[1]), name: fields[2], description: fields[3], unitPrice: double.Parse(fields[4]), pictureName: fields[5], vatRate: double.Parse(fields[6]));
                case "SOFT":
                    return new Soft(id: int.Parse(fields[1]), name: fields[2], description: fields[3], unitPrice: double.Parse(fields[4]), pictureName: fields[5], vatRate: double.Parse(fields[6]), volume: double.Parse(fields[7]));
                case "APERITIF":
                    return new Aperitif(id: int.Parse(fields[1]), name: fields[2], description: fields[3], unitPrice: double.Parse(fields[4]), pictureName: fields[5], vatRate: double.Parse(fields[6]), volume: double.Parse(fields[7]), percentage: double.Parse(fields[8]));
                case "BEER":
                    return new Beer(id: int.Parse(fields[1]), name: fields[2], description: fields[3], unitPrice: double.Parse(fields[4]), pictureName: fields[5], vatRate: double.Parse(fields[6]), volume: double.Parse(fields[7]), percentage: double.Parse(fields[8]), isTrappistBeer: bool.Parse(fields[9]), isAbbeyBeer: bool.Parse(fields[10]));
                default:
                    return null;
            }
        }

        /// <summary>
        /// AJOUTER ABSTRACT dans la classe DataAccess, mettre celle ci en OVERRIDE
        /// </summary>
        /// <returns></returns>
        public override CustomersCollection GetAllCustomers()
        {
            List<string> listToRead = new List<string>();
            CustomersCollection customers = new CustomersCollection();
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("PEOPLE");
            if (IsValidAccessPath)
            {
                listToRead = System.IO.File.ReadAllLines(AccessPath).ToList();
                //remove first title line
                listToRead.RemoveAt(0);
                foreach (string s in listToRead)
                {
                    Customer c = GetCustomer(s);
                    if (c != null)
                    {
                        customers.AddCustomer(c);
                    }
                }
                return customers;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }//end GetAllItems

        /// <summary>
        /// Split a line like : Customer;1;Beumier;Damien;true;beumierdamien@gmail.com;485678234;New;;;;
        /// and create instance with each fields.
        /// </summary>
        /// <param name="csvline"></param>
        /// <returns></returns>
        private static Customer GetCustomer(string csvline)
        {
            string[] fields = csvline.Split(';');
            if (!string.IsNullOrEmpty(fields[0]) && fields[0].Equals("CUSTOMER"))
            {
                Customer c = new Customer(id: int.Parse(fields[1]), lastName: fields[2], firstName: fields[3], gender: bool.Parse(fields[4]), email: fields[5], phone: fields[6], Customer.CustomerType.New);
                Customer.CustomerType cType;
                Enum.TryParse(fields[7], out cType);
                c.Type = cType;
                return c;
            }
            else
            {
                return null;
            }

        }
        public override TablesCollection GetTables()
        {
            List<string> listToRead = new List<string>();
            TablesCollection tables = new TablesCollection();
            string? AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("TABLES");
            if (IsValidAccessPath)
            {
                listToRead = System.IO.File.ReadAllLines(AccessPath).ToList();
                //remove first title line
                listToRead.RemoveAt(0);
                foreach (string s in listToRead)
                {
                    Table t = GetTable(s);
                    if (t != null)
                    {
                        tables.AddTable(t);
                    }
                }
                return tables;
            }
            else
            {
                //Console.WriteLine("GetAllItems Failes -> File doesnt exist");
                return null;
            }
        }

        /// <summary>
        /// Split a line like : 3;6
        /// and create table instance with each fields idNumber :3 and seatsNumber : 6.
        /// </summary>
        /// <param name="csvline"></param>
        /// <returns></returns>
        private static Table GetTable(string csvline)
        {
            string[] fields = csvline.Split(';');
            if (!string.IsNullOrEmpty(fields[0]))
            {
                Table t = new Table(idNumber: int.Parse(fields[0]), seatsNumber: int.Parse(fields[1]));
                return t;
            }
            else
            {
                return null;
            }
        }


        private static StaffMember GetStaffMember(string csvline)
        {
            string[] fields = csvline.Split(';');
            switch (fields[0])
            {
                case "STAFFMEMBER":
                    return new StaffMember(id : int.Parse(fields[1]), lastName:  fields[2] , firstName:  fields[3] , gender:  bool.Parse(fields[4]) ,email: fields[5] , phone: fields[6] , bankAccount: fields[7] , address: fields[9] , salary: double.Parse(fields[10]));

                case "MANAGER":
                    return new Manager(id: int.Parse(fields[1]), lastName: fields[2], firstName: fields[3], gender: bool.Parse(fields[4]), email: fields[5], phone: fields[6], bankAccount: fields[7], address: fields[9], salary: double.Parse(fields[10]) , password: fields[11]);

                default:
                    return null;
            }

        }




        /// <summary>
        /// Get All StaffMembers in a CSV File
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override StaffMembersCollection GetAllStaffMembers()
        {
            List<string> listToRead = new List<string>();
            StaffMembersCollection staffmembers = new StaffMembersCollection();
            AccessPath = DataFilesManager.DataFiles.GetFilePathByCodeFunction("PEOPLE");
            if (IsValidAccessPath)
            {
                listToRead = System.IO.File.ReadAllLines(AccessPath).ToList();
                //remove first title line
                listToRead.RemoveAt(0);
                foreach (string s in listToRead)
                {
                    StaffMember sm = GetStaffMember(s);
                    if (sm != null)
                    {
                        staffmembers.AddStaffmember(sm);
                    }
                }
                return staffmembers;
            }
            else
            {
                //Console.WriteLine("GetAllStaffMembers Failes -> File doesnt exist");
                return null;
            }
        }//end GetAllStaffMembers



        /// <summary>
        ///Convert "0" or "1" from csv File to bool type false or true
        ////// </summary>
        static private bool CvrtstrToBool(string field)
        {
            return Convert.ToBoolean(int.Parse(field));
        }

    }//end class DataAccessCsvFile
}
