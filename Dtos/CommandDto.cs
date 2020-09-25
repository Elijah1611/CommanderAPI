using System.ComponentModel.DataAnnotations;

namespace CmdApi.Dtos
{
    public class CommandDto

    {
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