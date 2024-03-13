using Brasserie.Model.Restaurant.Catering;
//using HealthKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Activity
{
    /// <summary>This class represent a line of an order. It contains an Item object, his quantity et his total price
    /// <example>For example:
    /// <code>
    /// Coca Cola 5 15.00€
    /// (item's name (Coca cola), unit price (3.00€) are included in the item object.)
    /// </code>
    /// </example>
    /// </summary>
    public class OrderItem
    {
        private Item _item;
        private int _quantity = 0;
        private double _price = 0.0;
        private double _vatCost = 0.0;
        
        
        public OrderItem(Item it, int qt)
        {
            Item = it;
            Quantity = qt;
        }
        /// <summary>
        /// item (drink, dish, ...) concerned in this orderItem
        /// </summary>
        public Item Item
        {
            get => _item;
            set
            {
                _item = value;
            }
        }
        /// <summary>
        /// Quantity ordered of this item
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                //OnPropertyChanged(nameof(Quantity));
                ComputePrice();
                ComputeVATCost();
            }
        }

        /// <summary>
        /// Total net price VAT incl. for this item ex 2 Coca Cola at 3.30€-> 6.60€
        /// </summary>
        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                ComputeVATCost();
            }
        }
        /// <summary>
        /// Total VAT cost ex : 2 Coca Cola at 3.30€-> 6.60€ -> VAT Cost 6.60*(21/121)
        /// </summary>
        public double VatCost
        {
            get => _vatCost;
            set
            {
                _vatCost = value;
            }
        }
        /// <summary>
        /// Compute total price for this item Ex : 2x3.30€->6.60€
        /// </summary>
        private void ComputePrice()
        {
            Price = Quantity * Item.UnitPrice;
        }

        /// <summary>
        /// Compute total VAT cost for this item Ex : 2x3.30€->6.60€
        /// </summary>
        private void ComputeVATCost()
        {
            VatCost = Price * Item.VatRate / (100.0 + Item.VatRate);
        }

    }//end OrderItem class





}
