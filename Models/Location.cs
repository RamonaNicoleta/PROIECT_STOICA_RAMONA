using System.ComponentModel.DataAnnotations;

namespace Proiect_Stoica_Ramona.Models
{
    public class Location
    {
        public int ID { get; set; }

        [Display(Name = "Location Name")]
        public string LocationName { get; set; }
        public ICollection<Car>? Cars { get; set; }

    }
}
