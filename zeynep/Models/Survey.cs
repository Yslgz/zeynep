using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace zeynep.Models
{
    public class Survey
    {
        [Key] //Primary Key
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Anket Sorusu Boş Bırakılamaz!")]
        [MaxLength(30)]
        [DisplayName("Anket Sorusu:")]
        public string Name { get; set; }    

    }
}
