using System.ComponentModel.DataAnnotations;

namespace CmdApi.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [MaxLength(250)]
        public string Snippet { get; set; }

        [Required]
        [MaxLength(100)]
        public string Platform { get; set; }

    }
}