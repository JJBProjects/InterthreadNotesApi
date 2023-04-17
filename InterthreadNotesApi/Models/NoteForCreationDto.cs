using System.ComponentModel.DataAnnotations;

namespace InterthreadNotesApi.Models
{
    public class NoteForCreationDto
    {
        [MaxLength(1000)]
        public string NoteText { get; set; } = string.Empty;
    }
}
