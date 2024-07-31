using System.ComponentModel.DataAnnotations;

namespace UsingDbContext.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Department { get; set; }
    }
}
