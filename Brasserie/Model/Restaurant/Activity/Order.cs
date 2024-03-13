using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model.Restaurant.Activity
{

    /// <summary>This class represent an customer order
    /// associating a list of OrderItems objects
    /// <example>For example:
    /// <code>
    /// 23/11/2025
    /// CocaCola 3 3.00€ 9.00€ -> first OrderItem obj
    /// Duvel 2 7.50€ 15.00€ -> second OrderItem obj
    /// Spagh bolo 1 18.00€ 15.00€
    /// Steak and French fries 2 26.00€ 52.00€
    ///
    /// Total VAT Price 19.11€
    /// Total Price 91.00€
    /// </code>
    /// </example>
    /// </summary>
    /// 

    public class Order
    {
        private ObservableCollection<OrderItem> _orderItems;
        private int _id;
        private double _totalPrice = 0.0;
        private double _totalVatCost = 0.0;
        private bool _toGo = false;
        public Order()
        {
            OrderItems = new ObservableCollection<OrderItem>();
        }
        /// <summary>
        /// Collection of OrderItems : ex 2 coca cola, 3 spaghettis bolognaise, ...
        /// </summary>
        public ObservableCollection<OrderItem> OrderItems
        {
            get => _orderItems;
            set
            {
                _orderItems = value;
                ComputeTotalPrice();
            }
        }
        /// <summary>
        /// unique Id of this Order
        /// </summary>
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        /// <summary>
        /// Total price at this time and for this meal (Sum of all OrderItems prices)
        /// </summary>
        public double TotalPrice
        {
            get => _totalPrice;
            private set
            {
                _totalPrice = value;
                ComputeVatCost();
            }
        }

        /// <summary>
        /// Total VAT cost at time and for this meal (Sum of all OrderItems VATcost)
        /// </summary>
        public double TotalVatCost
        {
            get => _totalVatCost;
            private set
            {
                _totalVatCost = value;
            }
        }
        /// <summary>
        /// true if do not eat in but take away
        /// </summary>
        public bool ToGo
        {
            get => _toGo;
            set => _toGo = value;
        }
        /// <summary>
        /// Compute Total price at this time and for this meal, Sum of all orderItems Prices
        /// </summary>
        private void ComputeTotalPrice()
        {
            TotalPrice = OrderItems.Sum(orItem => orItem.Price);
        }

        /// <summary>
        /// Compute Total VAT cost at this time and for this meal, Sum of all orderItems Vat cost
        /// </summary>
        private void ComputeVatCost()
        {
            TotalVatCost = OrderItems.Sum(orItem => orItem.VatCost);
        }
        /// <summary>
        /// Add or update an OrderItem of this Order with a new OrderItem object
        /// </summary>
        /// <param name="newOrderItem"></param>
        public void AddUpdateOrderItem(OrderItem newOrderItem)
        {
            if (!OrderItems.Any(oi => oi.Item.Id == newOrderItem.Item.Id))
            {
                OrderItems.Add(newOrderItem); //not already in this order, simply add this orderItem
            }
            else
            {
                OrderItem oItem = OrderItems.First(oi => oi.Item.Id == newOrderItem.Item.Id);
                oItem.Quantity += newOrderItem.Quantity; //orderItem already in this order -> merge quantity with new OrderItem
            }
            ComputeTotalPrice();
        }
        /// <summary>
        /// prints the receipt as the customer will receive it
        /// </summary>
        public void PrintTicket()
        {
            //not implemented for now
        }
    }//end Order class




}
