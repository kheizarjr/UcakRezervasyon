using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcakRezervasyon.Models
{
    public class guzergah
    {
        [Key]
        public int guzergahId { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string guzergahName { get; set; }

       

    }
}
