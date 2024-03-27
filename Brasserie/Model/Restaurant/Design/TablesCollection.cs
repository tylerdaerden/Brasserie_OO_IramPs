using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Brasserie.Model.Restaurant.Design
{
    public class TablesCollection : ObservableCollection<Table>
    {

        public TablesCollection() { }

        public TablesCollection(IEnumerable<Table> collection) : base(collection)
        {
            // Vous pouvez ajouter des initialisations spécifiques ici si nécessaire
        }

        public void AddTable(Table t)
        {
            if (!this.Any(tobjet => tobjet.IdNumber == t.IdNumber))
            {
                this.Add(t);
            }
            else
            {
                //gérer une exception
                //Debug.WriteLine("Id already in the collection");
            }


        }
        static public TablesCollection ConvertToTablesCollection(ObservableCollection<object> objCollection) 
        {
            TablesCollection tablesCollection = new TablesCollection();
            foreach (var item in objCollection.OfType<Table>())
            {
                tablesCollection.Add(item);
            }
            return tablesCollection;

        }

    }
}
