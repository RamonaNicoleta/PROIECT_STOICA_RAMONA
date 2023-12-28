using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Proiect_Stoica_Ramona.Models
{
    public class Rent
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? CarID { get; set; }
        public Car? Car { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

    }
}
