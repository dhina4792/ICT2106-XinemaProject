using System.ComponentModel.DataAnnotations;

namespace XinemaProject.Models
{
    public class Showtimes
    {
        public int showtimesID { get; set; }
        [DataType(DataType.Time)]
        public string showtimesStartTime { get; set; }
        [DataType(DataType.Date)]
        public string showtimesDate { get; set; }

    }
}