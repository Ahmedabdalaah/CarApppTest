using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarApppTest.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Car Name")]
        public string Name { get; set; }
        [Required]
        public int year { get; set; }
        [ForeignKey("category")]
        public int CategoryId { get; set; } 
        public Category? category { get; set; }
    }
}
