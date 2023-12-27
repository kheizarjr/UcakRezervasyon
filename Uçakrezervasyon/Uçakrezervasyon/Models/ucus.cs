using System.ComponentModel.DataAnnotations;

namespace UcakRezervasyon.Models
{
    public class ucus
    {
        public int ucusId { get; set; }

        public int ucakId { get; set; }

        public int guzergahId { get; set; }

        [Required]
        public int koltukNo { get; set; }
    }
}
