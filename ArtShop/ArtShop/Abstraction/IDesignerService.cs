using ArtShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Abstraction
{
    public interface IDesignerService
    {
        List<Designer> GetDesigners();
        Designer GetDesignerById(int designerId);
        List<Product> GetProductsByDesigner(int designerId);
    }
}
