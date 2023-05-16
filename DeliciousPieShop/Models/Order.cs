using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace DeliciousPieShop.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }

        [Required(ErrorMessage ="Please enter your first name")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please enter your last name")]
        [Display(Name ="Last Name")]
        [StringLength (50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please enter Address Line 1")]
        [Display (Name ="Address Line 1")]
        [StringLength(100)]
        public string AddressLine1 { get; set; } = string.Empty;

        [Display(Name =("Address Line 2"))]
        [StringLength (100)]
        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage ="Please enter the zipcode")]
        [Display(Name ="Zip Code")]
        [StringLength(6)]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please enter City")]
        [Display(Name ="City")]
        public string City { get; set; } = string.Empty;

        [Display(Name ="State")]
        public string? State { get; set; }

        [Required (ErrorMessage ="Please enter Country")]
        [Display(Name = "Country")]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please enter Phone Number")]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please enter Email")]
        [Display(Name ="Email")]
        [StringLength (50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}",ErrorMessage ="Emails is not in correct format.")]
        public string Email { get; set; } = string.Empty;

        [BindNever]
        public decimal OrderTotal { get; set; }
        [BindNever]
        public DateTime OrderPlaced { get; set; }
        
    }
}
