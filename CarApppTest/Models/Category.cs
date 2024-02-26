using System.ComponentModel.DataAnnotations;

namespace CarApppTest.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Car> cars { get; set; }
    }
}
