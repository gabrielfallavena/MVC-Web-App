using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Services
{
    public class SalesRecordService
    {
        private readonly WebApp1Context _context;

        public SalesRecordService(WebApp1Context context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? min, DateTime? max)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (min.HasValue)
            {
                result = result.Where(p => p.Date >= min.Value);
            }
            if (max.HasValue)
            {
                result = result.Where(p => p.Date <= max.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? min, DateTime? max)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (min.HasValue)
            {
                result = result.Where(p => p.Date >= min.Value);
            }
            if (max.HasValue)
            {
                result = result.Where(p => p.Date <= max.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }


    }
}
