using InterthreadNotesApi.Entities;

namespace InterthreadNotesApi.Services
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetNotesAsync();
        Task<IEnumerable<Note>> GetNotesForUserAsync(int userId);
        Task<Note?> GetNoteForUserAsync(int userId, int noteId);
        Task AddNoteForUserAsync(int userId, Note note);
    }
}
