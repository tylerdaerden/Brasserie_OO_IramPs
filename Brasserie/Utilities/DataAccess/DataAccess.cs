using Brasserie.Model.Restaurant.Catering;
using Brasserie.Model.Restaurant.Design;
using Brasserie.Model.Restaurant.People;
using Brasserie.Utilities.DataAccess.Files;
using Brasserie.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Brasserie.Utilities.DataAccess
{
    public abstract class DataAccess : IDataAccess
    {
        private string _accessPath;
        /// <summary>
        /// constructor with just the fileName for AccessPath
        /// </summary>
        /// <param name="filePath"></param>
        public DataAccess(string filePath)
        {
            AccessPath = filePath;
        }
        /// <summary>
        /// Constructor with fileName only one and authorized file extensions
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="extensions"> Exemple {".xlxs",".json"}</param>
        public DataAccess(string filePath, string[] extensions)
        {
            Extensions = new List<string>(extensions.ToList());
            AccessPath = filePath;
        }
        /// <summary>
        /// Constructor associated with a DatafileManager object, it will contains all datas files informations (path and subject)
        /// </summary>
        /// <param name="dfm"></param>
        public DataAccess(DataFilesManager dfm)
        {
            this.DataFilesManager = dfm;
        }
        public DataFilesManager DataFilesManager { get; set; }
        /// <summary>
        /// AccessPath file to the data source
        /// </summary>
        /// 
        public virtual string AccessPath
        {
            get => _accessPath;
            set
            {
                _accessPath = value;
            }
        }//end AccessPath
        /// <summary>
        /// List of authorized extensions .txt, csv, .Json, .xml ...for the AccessPath file
        /// </summary>
        public List<string> Extensions { get; set; }
        /// <summary>
        /// Continue to check AccessPath even after constructor (in the case of the file may be moved, renamed or deleted)
        /// </summary>
        public bool IsValidAccessPath => CheckAccessPath(AccessPath);
        public abstract ItemsCollection GetAllItems();
        public abstract TablesCollection GetTables();
        public abstract CustomersCollection GetAllCustomers();
        public abstract StaffMembersCollection GetAllStaffMembers();

        /// <summary>
        /// Check AccessPath to the data source file. File path must exist and if
        /// extensions are specified, the extension file must match to one of them
        /// </summary>
        /// <returns>true if valid path and extension file</returns>
        public bool CheckAccessPath(string tryPath)
        {
            if (File.Exists(tryPath))
            {
                if (Extensions?.Any() ?? false)
                {
                    string pattern = "";
                    foreach (string ext in Extensions)
                    {
                        pattern += ext + "|";
                    }
                    pattern = pattern.Substring(0, pattern.Length - 1);
                    //check extension file
                    if (!Regex.IsMatch(tryPath, pattern + "$")) //pattern exemple = ".txt|.csv$"
                    {
                        Console.WriteLine($"L'extension du fichier {tryPath} n'est pas valide, extensions attendues : {pattern}", "Erreur de fichier");
                        return false;
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }

            else
            {
                Console.WriteLine($"Le fichier {tryPath} n'existe pas", "Erreur de fichier");
                return false;
            }
        }

    }//end class DataAccess
}
