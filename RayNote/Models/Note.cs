using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RayNote.Models
{
    public class Note
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        public int Timestamp { get; set; }
        [Required]
        public int OwnerId { get; set; }
        public override string ToString()
        {
            return Id.ToString() + "/" + Title + "/" + Content + "/" + Timestamp.ToString() + "/" + OwnerId.ToString();
        }
    }
}
