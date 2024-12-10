using System.ComponentModel.DataAnnotations;

namespace zeynep.Models
{
    public class Anketler
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AnketAdi { get; set; }
        public string Tanim { get; set; }

        [Required]
        public string AnketYazari {  get; set; }    

    }
}
