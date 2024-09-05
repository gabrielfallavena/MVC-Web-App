using Mysqlx.Prepare;

namespace WebApp1.Models
{
    public class Department
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        public Department() { }

        public Department(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public void AddSeller(Seller s)
        {
            Sellers.Add(s);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sellers.Sum(s => s.TotalSales(initial, final));
            //Retorna a soma do total de somas de cada vendedor deste departamanto
        }

    }
}
