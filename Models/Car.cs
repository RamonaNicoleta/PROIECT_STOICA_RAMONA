
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proiect_Stoica_Ramona.Models
{
    public class Car
    {

        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }
        [Display(Name = "Availabe Date")]

        [DataType(DataType.Date)]
        public DateTime AvailabeDate { get; set; }
        public string? Model { get; set; }
        [Column(TypeName = "decimal(18, 2)")]

        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int? LocationID { get; set; }

        public Location? Location { get; set; }


        public int? RentID { get; set; }
        public Rent? Rent { get; set; }

        public List<EngineType> EngineTypes { get; set; } = new List<EngineType>();








    }



}
