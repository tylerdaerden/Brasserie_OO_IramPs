using Brasserie.Model.Restaurant.Catering;
using Brasserie.Model.Restaurant.Design;
using Brasserie.Model.Restaurant.People;
using Brasserie.Utilities.DataAccess.Files;
using Brasserie.Utilities.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Utilities.DataAccess
{
    public class DataAccessSql : DataAccess, IDataAccess
    {
        public DataAccessSql(DataFilesManager dfm, IAlertService alertService) : base(dfm, alertService)
        {
            try
            {
                AccessPath = DataFilesManager.DataFiles.GetValueByCodeFunction("CONNECTION_STRING");
                //const string CONN_STRING = @"Data Source=PORTABLE_DENYS\DATAIRAMPS;Initial Catalog=BrasserieDatabase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
                SqlConnection = new SqlConnection(AccessPath);
                SqlConnection.Open();
            }
            catch (Exception ex)
            {
                // Exception handling
            }
        }

        /// <summary>
        /// Connection to the database
        /// </summary>
        public SqlConnection SqlConnection { get; set; }

        public override CustomersCollection GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public override ItemsCollection GetAllItems()
        {
            try
            {
                ItemsCollection items = new ItemsCollection();
                //not implemented
                return items;
            }
            catch (Exception ex)
            {
                alertService.ShowAlert("Database Request Error", ex.Message);
                return null;
            }
        }

        public override StaffMembersCollection GetAllStaffMembers()
        {
            try
            {
                StaffMembersCollection staffMembers = new StaffMembersCollection();
                string sql = "SELECT * FROM StaffMembers;";
                SqlCommand cmd = new SqlCommand(sql, SqlConnection);
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    StaffMember sm = GetStaffMember(dataReader);
                    if (sm != null)
                    {
                        staffMembers.Add(sm);
                    }
                }
                dataReader.Close();
                return staffMembers;
            }
            catch (Exception ex)
            {
                alertService.ShowAlert("Database Request Error", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Reads data from SqlDataReader and creates a StaffMember object.
        /// </summary>
        /// <param name="dr">SqlDataReader containing staff member data</param>
        /// <returns>StaffMember object</returns>
        private static StaffMember GetStaffMember(SqlDataReader dr)
        {
            string type = dr.GetValue(1).ToString();

            switch (type)
            {
                case "StaffMember":
                    return new StaffMember(
                        id: dr.GetInt32(0),
                        lastName: dr.GetString(2),
                        firstName: dr.GetString(3),
                        gender: dr.GetBoolean(7),
                        email: dr.GetString(6),
                        phone: dr.GetString(5),
                        bankAccount: dr.GetString(8),
                        address: dr.GetString(4),
                        salary: dr.GetDouble(9)
                    );

                case "Manager":
                    return new Manager(
                        id: dr.GetInt32(0),
                        lastName: dr.GetString(2),
                        firstName: dr.GetString(3),
                        gender: dr.GetBoolean(7),
                        email: dr.GetString(6),
                        phone: dr.GetString(5),
                        bankAccount: dr.GetString(8),
                        address: dr.GetString(4),
                        salary: dr.GetDouble(9),
                        login: dr.GetString(10),
                        password: dr.GetString(11)
                    );

                default:
                    return null;
            }
        }


        public override TablesCollection GetTables()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update StaffMembers database table from the staff members collection.
        /// </summary>
        /// <param name="staffMembers">Collection of staff members to update</param>
        /// <returns>True if the update was successful, otherwise false</returns>
        public override bool UpdateAllStaffMembers(StaffMembersCollection staffMembers)
        {
            string sql = string.Empty;

            try
            {
                foreach (StaffMember sm in staffMembers)
                {
                    // If the ID already exists in the database, update its values; otherwise, insert it as a new record.
                    sql = IsInDb(sm.Id, "Id", "StaffMembers") ? GetSqlUpdateStaffMember(sm) : GetSqlInsertStaffMember(sm);

                    if (!string.IsNullOrEmpty(sql))
                    {
                        // Execute the SQL command.
                        SqlCommand command = new SqlCommand(sql, SqlConnection);
                        int insertedId = Convert.ToInt32(command.ExecuteScalar()); // Get the auto-generated ID from the database.

                        if (insertedId > 0)
                        {
                            sm.Id = insertedId; // Update the ID of the staff member.
                        }
                    }
                }

                return true; // Update successful.
            }
            catch (Exception ex)
            {
                // Handle exceptions and show an alert.
                alertService.ShowAlert("Database Request Error", $"{ex.Message} \nSQL Query : {sql}");
                return false; // Update failed.
            }
        }


        /// <summary>
        /// Creates a SQL request for updating the staff member's information based on their type and properties.
        /// </summary>
        /// <param name="sm">Staff member object to update</param>
        /// <returns>SQL UPDATE request</returns>
        private string GetSqlUpdateStaffMember(StaffMember sm)
        {
            // Get the type of the staff member.
            string[] strType = sm.GetType().ToString().Split('.');
            string type = strType[strType.Length - 1];

            switch (type)
            {
                case "StaffMember":
                    // Construct SQL query for updating a StaffMember.
                    return $"UPDATE StaffMembers SET " +
                           $"FirstName = '{sm.FirstName}', " +
                           $"LastName = '{sm.LastName}', " +
                           $"Address = '{sm.Address}', " +
                           $"MobilePhone = '{sm.MobilePhoneNumber}', " +
                           $"EMail = '{sm.Email}', " +
                           $"Gender = {BoolSqlConvert(sm.Gender)}, " +
                           $"BankAccount = '{sm.BankAccount}' " +
                           $"WHERE Id = {sm.Id};";

                case "Manager":
                    // Cast to Manager object.
                    Manager m = (Manager)sm;
                    // Construct SQL query for updating a Manager.
                    return $"UPDATE StaffMembers SET " +
                           $"FirstName = '{sm.FirstName}', " +
                           $"LastName = '{sm.LastName}', " +
                           $"Address = '{sm.Address}', " +
                           $"MobilePhone = '{sm.MobilePhoneNumber}', " +
                           $"EMail = '{sm.Email}', " +
                           $"Gender = {BoolSqlConvert(sm.Gender)}, " +
                           $"BankAccount = '{sm.BankAccount}', " +
                           $"Login = '{m.Login}' " +
                           $"WHERE Id = {sm.Id};";

                default:
                    // If the type is not recognized, return null.
                    return null;
            }
        }


        /// <summary>
        /// Creates a SQL request to insert a new staff member into the database with their properties.
        /// </summary>
        /// <param name="sm">Staff member object to insert</param>
        /// <returns>SQL INSERT request</returns>
        private string GetSqlInsertStaffMember(StaffMember sm)
        {
            // Get the type of the staff member.
            string[] strType = sm.GetType().ToString().Split('.');
            string type = strType[strType.Length - 1];

            switch (type)
            {
                case "StaffMember":
                    // Construct SQL query for inserting a StaffMember.
                    return $"INSERT INTO StaffMembers (Type, FirstName, LastName, Address, MobilePhone, EMail, Gender, BankAccount) " +
                           $"VALUES ('{type}', '{sm.FirstName}', '{sm.LastName}', '{sm.Address}', '{sm.MobilePhoneNumber}', '{sm.Email}', " +
                           $"{BoolSqlConvert(sm.Gender)}, '{sm.BankAccount}'); SELECT SCOPE_IDENTITY();";

                case "Manager":
                    // Cast to Manager object.
                    Manager m = (Manager)sm;
                    // Construct SQL query for inserting a Manager.
                    return $"INSERT INTO StaffMembers (Type, FirstName, LastName, Address, MobilePhone, EMail, Gender, BankAccount, Login) " +
                           $"VALUES ('{type}', '{sm.FirstName}', '{sm.LastName}', '{sm.Address}', '{sm.MobilePhoneNumber}', '{sm.Email}', " +
                           $"{BoolSqlConvert(sm.Gender)}, '{sm.BankAccount}', '{m.Login}'); SELECT SCOPE_IDENTITY();";

                default:
                    // If the type is not recognized, return null.
                    return null;
            }
        }


        /// <summary>
        /// Checks if a given ID exists in the specified table of the database.
        /// </summary>
        /// <param name="idValue">ID value to check</param>
        /// <param name="idColumnName">Name of the ID column</param>
        /// <param name="tableName">Name of the table</param>
        /// <returns>True if the ID is found in the database, otherwise false</returns>
        private bool IsInDb(int idValue, string idColumnName, string tableName)
        {
            string sql = $"SELECT * FROM {tableName} WHERE {idColumnName} = {idValue}";

            // Execute the SQL command.
            SqlCommand cmd = new SqlCommand(sql, SqlConnection);
            SqlDataReader dataReader = cmd.ExecuteReader();

            // Check if any rows are returned.
            bool inDb = dataReader.HasRows;

            // Close the data reader.
            dataReader.Close();

            return inDb;
        }

        /// <summary>
        /// Converts a boolean value to its equivalent string representation for SQL queries.
        /// </summary>
        /// <param name="b">Boolean value to convert</param>
        /// <returns>String representation ("1" for true, "0" for false)</returns>
        private string BoolSqlConvert(bool b)
        {
            return b ? "1" : "0";
        }

    }

}