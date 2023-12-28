using System.ComponentModel.DataAnnotations;
using Proiect_Stoica_Ramona.Models;

namespace Proiect_Stoica_Ramona.Models
{
    public class EngineType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Assigned")]
        public bool Assigned { get; set; } // Property to determine if an engine type is assigned/selected
    }
}
