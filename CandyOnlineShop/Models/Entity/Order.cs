using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandyOnlineShop.Models.Entity
{
    public class Order
    {
        [BindNever]
        [Column("OrderId")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter your First Name")]
        [StringLength(25)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter your Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your Street Address")]
        [Display(Name = "Street Address")]
        [StringLength(100)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter your City Name")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your State Name")]
        [StringLength(3), MinLength(2)]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter your Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [BindNever]
        public decimal Total { get; set; }
        public DateTime OrderPlaced { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
