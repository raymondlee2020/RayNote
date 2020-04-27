using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RayNote.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Account { get; set; }
        [Required]
        public string Password { get; set; }
        public override string ToString()
        {
            return Id.ToString() + "/" + Name + "/" + Account + "/" + Password;
        }
    }
}
