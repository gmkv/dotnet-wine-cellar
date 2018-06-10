using System.ComponentModel.DataAnnotations;

namespace gm18119.Models
{
    public class Wine
    {
        public int Id { get; set; }
        
        [Display(Name = "Style"), Required]
        public StyleType Style { get; set; }

        [Display(Name = "Selling price"), Required, Range(0.0,double.MaxValue)]
        public double SellingPrice { get; set; }
        
        [Display(Name = "Buying price"), Required, Range(0.0,double.MaxValue)]
        public double BuyingPrice { get; set; }
        
        [Display(Name = "Remaining bottles"), Required, Range(0, int.MaxValue)]
        public int BottlesRemaining { get; set; }
        
        [Display(Name = "Vineyard"), Required, MaxLength(100)]
        public string Vineyard { get; set; }
        
        [Display(Name = "Location"), Required, MaxLength(100)]
        public string Location { get; set; }
        
        [Display(Name = "Year"), Required, MinLength(4), MaxLength(4)]
        public string Year { get; set; }
        
        [Display(Name = "Tasting notes"), Required, MaxLength(140)]
        public string TastingNotes { get; set; }

    }
}