using Microsoft.EntityFrameworkCore;
using WebApp1.Models;

namespace WebApp1.Services
{
    public class DepartmentService
    {
        private readonly WebApp1Context _context;

        public DepartmentService(WebApp1Context context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

    }
}
