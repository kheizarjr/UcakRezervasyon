using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcakRezervasyon.Models
{
    public class ucus
    {
        [Key]
        public int ucusId { get; set; }

        [ForeignKey("ucak")]
        public int ucakId { get; set; }
        public virtual ucak ucak { get; set; }

        [ForeignKey("guzergah")]
        public int guzergahId { get; set; }
        public virtual guzergah guzergah { get; set; }

       

        
    }
}
