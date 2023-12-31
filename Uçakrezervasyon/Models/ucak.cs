using System.ComponentModel.DataAnnotations;

namespace UcakRezervasyon.Models
{
    public class ucak
    {
        [Key]
        public int ucakId { get; set; }

        [Required]
        [MaxLength(5)]
        [MinLength(3)]
        public string ucakName { get; set; }

        public int koltukSayisi { get; set; }

       
    }
}
