using WebApp1.Models;

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


    }
}
