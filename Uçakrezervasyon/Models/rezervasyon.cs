using System.ComponentModel.DataAnnotations;

namespace UcakRezervasyon.Models
{
    public class rezervasyon
    {
        [Key]
        public int rezervasyonId { get; set; }

        public int ucusId { get; set; }
        public virtual ucus ucus { get; set; }

        public int KoltukNo { get; set; }
    }
}
