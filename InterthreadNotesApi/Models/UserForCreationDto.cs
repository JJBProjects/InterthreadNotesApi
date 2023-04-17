using System.ComponentModel.DataAnnotations;

namespace InterthreadNotesApi.Models
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "A username is required.")]
        [MaxLength(50)]
        public string UserName { get; set; }
    }
}
