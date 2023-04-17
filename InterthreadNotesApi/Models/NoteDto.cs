using InterthreadNotesApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InterthreadNotesApi.Models
{
    public class NoteDto
    {
        public int UserId { get; set; }

        public int NoteId { get; set; }

        public string NoteText { get; set; }

        public DateTime NoteCreatedTimestamp { get; set; }
    }
}
