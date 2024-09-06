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

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

    }
}
