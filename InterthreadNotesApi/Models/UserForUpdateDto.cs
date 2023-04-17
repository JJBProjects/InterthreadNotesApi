using System.ComponentModel.DataAnnotations;

namespace InterthreadNotesApi.Models
{
    public class UserForUpdateDto
    {
        [Required(ErrorMessage = "A username is required.")]
        [MaxLength(50)]
        public string UserName { get; set; } = string.Empty;
    }
}
