
namespace dal.entities
{
    internal class Owner {
        public int id { get; set; }
        public string first_name { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public DateOnly date_of_birth { get; set; }
    }
}
