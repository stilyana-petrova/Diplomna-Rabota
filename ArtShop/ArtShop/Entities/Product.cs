using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Entities
{
    public class Product
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        [Required]
        public int DesignerId { get; set; }
        public virtual Designer Designer { get; set; }


        [Required]
        public string Description { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 100)]
        public int Quantity { get; set; }

        public decimal Discount { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }

}
