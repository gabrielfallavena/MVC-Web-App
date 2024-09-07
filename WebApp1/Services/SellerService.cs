using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApp1.Models;
using WebApp1.Services.Exceptions;

namespace WebApp1.Services
{
    public class SellerService
    {
        private readonly WebApp1Context _context;

        public SellerService(WebApp1Context context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList(); //Aplicação sincrona
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
            //Include permite obter outros objetos associados ao objeto principal
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(obj => obj.Id == seller.Id)) throw new NotFoundException("Id not found");
            
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}
