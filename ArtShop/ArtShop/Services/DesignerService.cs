using ArtShop.Abstraction;
using ArtShop.Data;
using ArtShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Services
{
    public class DesignerService :IDesignerService
    {
        private readonly ApplicationDbContext _context;
        public DesignerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Designer GetDesignerById(int designerId)
        {
            return _context.Designers.Find(designerId);
        }

        public List<Designer> GetDesigners()
        {
            List<Designer> designers = _context.Designers.ToList();
            return designers;
        }

        public List<Product> GetProductsByDesigner(int designerId)
        {
            return _context.Products.Where(x => x.DesignerId == designerId).ToList();
        }
    }
}
