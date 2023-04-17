using InterthreadNotesApi.DbContexts;
using InterthreadNotesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterthreadNotesApi.Services
{
    public class NoteRepository : INoteRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly AppDbContext _context;

        public NoteRepository(IUserRepository userRepository, AppDbContext context)
        {
            _userRepository = userRepository;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// A note is created with a generated timestamp and specified user Id
        /// </summary>
        /// <param name="userId">The user creating the note</param>
        /// <param name="note">The note object containing text</param>
        public async Task AddNoteForUserAsync(int userId, Note note)
        {
            var user = await _userRepository.GetUserAsync(userId);
            if (user != null)
            {
                note.UserId = userId;
                note.NoteCreatedTimestamp = DateTime.UtcNow;
                user.Notes.Add(note);
            }
        }

        /// <summary>
        /// A single note identified by the creating user and the note id is returned
        /// </summary>
        /// <param name="userId">The user author of the note</param>
        /// <param name="noteId">The unique note identifier</param>
        /// <returns>Single Note object</returns>
        public async Task<Note?> GetNoteForUserAsync(int userId, int noteId)
        {
            return await _context.Notes
               .Where(x => x.UserId == userId && x.NoteId == noteId)
               .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Returns all notes in the database ordered by user id then by creation
        /// </summary>
        /// <returns>List of Note objects</returns>
        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            return await _context.Notes.OrderBy(x => x.UserId).ThenBy(x => x.NoteCreatedTimestamp)
                .ToListAsync();
        }

        /// <summary>
        /// Returns a list of all notes ordered by creation for a specified user 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List of note objects</returns>
        public async Task<IEnumerable<Note>> GetNotesForUserAsync(int userId)
        {
            return await _context.Notes.OrderBy(x => x.NoteCreatedTimestamp)
               .Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
