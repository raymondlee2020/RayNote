using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RayNote.Models
{
    public class Note
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public long Timestamp { get; set; }
        [Required]
        public int OwnerId { get; set; }
        public override string ToString()
        {
            return Id.ToString() + "/" + Title + "/" + Content + "/" + Timestamp.ToString() + "/" + OwnerId.ToString();
        }
    }
}
