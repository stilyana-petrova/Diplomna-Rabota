using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Entities
{
    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<Order>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        [Required]
        public int DesignerId { get; set; }
        public Designer Designer { get; set; }


        [Required]
        public string Description { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int Discount { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
