using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Models.Designer
{
    public class DesignerPairVM
    {
        public int Id { get; set; }
        [Display(Name ="Designer")]
        public string Name { get; set; }
    }
}
