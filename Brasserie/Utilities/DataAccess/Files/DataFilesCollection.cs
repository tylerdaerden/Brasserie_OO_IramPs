using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Utilities.DataAccess.Files
{
    public class DataFilesCollection : List<DataFile>

    {
        public DataFilesCollection() 
        {            
        }          
            
        public void AddFile(DataFile df) 
        {
            this.Add(df);
        }

        /// <summary>
        /// get full path file for a specific function ("ITEMS","TABLES","BOOKINGS",...)
        /// </summary>
        /// <param name="concern"></param>
        /// <returns></returns>
        public string? GetFilePathByCodeFunction(string concern) => this.Find(df => df.Concern.Equals(concern))?.FullPath;
    }
}
