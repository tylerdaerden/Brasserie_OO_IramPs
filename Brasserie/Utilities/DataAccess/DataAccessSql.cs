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
                // Récupérer tous les IDs depuis le serveur SQL
                List<int> sqlIds = new List<int>();
                string sqlQuery = $"SELECT Id FROM StaffMembers";
                SqlCommand selectCommand = new SqlCommand(sqlQuery, SqlConnection); // Renommage de la variable ici
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    sqlIds.Add(reader.GetInt32(0));
                }
                reader.Close();
                // Comparer les IDs avec ceux dans votre programme
                List<int> programIds = new List<int>();
                foreach (StaffMember sm in staffMembers)
                {
                    programIds.Add(sm.Id);
                }
                // Trouver les IDs manquants
                List<int> missingIds = sqlIds.Except(programIds).ToList();

                // Supprimer les IDs manquants de votre programme
                foreach (int missingId in missingIds)
                {
                    // Supprimer l'ID manquant de votre base de données
                    string deleteSql = $"DELETE FROM StaffMembers WHERE Id = {missingId}";
                    SqlCommand deleteCommand = new SqlCommand(deleteSql, SqlConnection);
                    deleteCommand.ExecuteNonQuery();
                }

                foreach (StaffMember sm in staffMembers)
                {

                    //if id already in databse, update his values, insert in the other case
                    sql = IsInDb(sm.Id, "Id", "StaffMembers") ? GetSqlUpdateStaffMember(sm) : GetSqlInsertStaffMember(sm);
                    if (!string.IsNullOrEmpty(sql))
                    {
                        //Console.WriteLine(sql);
                        SqlCommand command = new SqlCommand(sql, SqlConnection);
                        //command.ExecuteNonQuery(); //common Execute without getting id value
                        //get id autocreated by the database (when update insertedId = 0)
                        int insertedId = Convert.ToInt32(command.ExecuteScalar());
                        if (insertedId > 0)
                        {
                            sm.Id = insertedId;
                        }
                    }
                    else
                    {

                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                alertService.ShowAlert("Database Request Error", $"{ex.Message} \nSQL Query: {sql}");
                return false;
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
        /// create a sql request. Insert the staffMember fonction of his type and his internal properties values.
        /// </summary>
        /// <param name="sm"></param>
        /// <returns>sql INSERT request</returns>
        private string GetSqlInsertStaffMember(StaffMember sm)
        {
            string[] strType = sm.GetType().ToString().Split('.');
            string type = strType[strType.Length - 1];
            switch (type)

            {
                case "StaffMember":

                    return $"INSERT INTO StaffMembers (Type, FirstName ,LastName,Address, MobilePhone, EMail, Gender, BankAccount, Salary) VALUES('{type}','{sm.FirstName}','{sm.LastName}','{sm.Address}','{sm.MobilePhoneNumber}','{sm.Email}',{BoolSqlConvert(sm.Gender)},'{sm.BankAccount}',{sm.GetSalary});SELECT SCOPE_IDENTITY();";
                case "Manager":
                    Manager m = (Manager)sm;
                    return $"INSERT INTO StaffMembers (Type, FirstName ,LastName,Address, MobilePhone, EMail, Gender, BankAccount, Salary, Login ) VALUES('{type}','{sm.FirstName}','{sm.LastName}','{sm.Address}','{sm.MobilePhoneNumber}','{sm.Email}',{BoolSqlConvert(sm.Gender)},'{sm.BankAccount}',{sm.GetSalary},'{m.Login}');SELECT SCOPE_IDENTITY();";

                default:

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