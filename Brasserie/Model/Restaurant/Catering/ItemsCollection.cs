using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Catering
{
    public class ItemsCollection : ObservableCollection<Item>
    {

        public ItemsCollection() { }

        /// <summary>
        /// add new item in the collection checking if this item isn't already inside checking by the Id and the Name
        /// </summary>
        /// <param name="it"></param>
        public new void AddItem(Item it)
        {
            if (!this.Any(ItemInTheCollection => ItemInTheCollection.Id == it.Id || ItemInTheCollection.Name == it.Name))
            {
                this.Add(it);
            }
            else
            {
                //id item or item name already in the collection and will not be added.
            }
        }

        /// <summary>
        /// Remove a specific item in the collection (if it exist)
        /// </summary>
        /// <param name="it"></param>
        public void DeleteItem(Item it)
        {
            if (this.Contains(it))
            {
                this.Remove(it);
            }
        }

        /// <summary>
        /// index all UnitPrices by a specific percentage 
        /// </summary>
        /// <param name="indexPercentage"></param>
        public void IndexPrices(double indexPercentage)
        {
            this.ToList().ForEach(it => it.UnitPrice *= 1 + (indexPercentage / 100));


        }

        /// <summary>
        /// Sort Dishes from the items collection
        /// </summary>
        public List<Dish> Dishes => this.OfType<Dish>().ToList();

        /// <summary>
        /// Sort Softs from the items collection
        /// </summary>
        public List<Soft> Softs => this.OfType<Soft>().ToList();

        /// <summary>
        /// Sort Beers from the items collection
        /// </summary>
        public List<Beer> Beers => this.OfType<Beer>().ToList();

        /// <summary>
        /// Sort Aperitifs from the items collection
        /// </summary>
        public List<Aperitif> Aperitifs => this.OfType<Aperitif>().ToList();



    }

}

