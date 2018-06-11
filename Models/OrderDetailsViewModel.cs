using System.Collections.Generic;

namespace gm18119.Models
{
    // OrderDetailViewModel class serves as a means to transport an Order and the wines that have been purchased from the OrderController to the Details Action
    public class OrderDetailsViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<Wine> PurchasedWines { get; set; }

    }
}