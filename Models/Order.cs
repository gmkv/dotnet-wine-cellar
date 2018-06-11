using System.ComponentModel.DataAnnotations;

namespace gm18119.Models
{
    public class Order
    {
        [Display(Name = "Order number"), Required]
        public int Id { get; set; }

        // [Display(Name = "Purchased wines"), Required]
        // public int[][] OrderedWineIds { get; set; }

        [Display(Name = "Purchased wines"), Required]
        public string OrderedWineIds { get; set; }

        [Display(Name = "Total amount due"), Range(0.0, double.MaxValue),Required]
        public double TotalAmountDue { get; set; } // could be Invoice.Id
        
        [Display(Name = "Status"), Required]
        public OrderStatus Status { get; set; }

    }

    public enum OrderStatus {
        Cancelled,
        Delivered,
        InTransit,
        Processing
    }
}