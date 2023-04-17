using InterthreadNotesApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InterthreadNotesApi.Models
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}
