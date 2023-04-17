using AutoMapper;
using InterthreadNotesApi.Models;
using InterthreadNotesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterthreadNotesApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public NotesController(INoteRepository noteRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _noteRepository = noteRepository ??
                throw new ArgumentNullException(nameof(noteRepository));
            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("getallnotes", Name = "GetAllNotes")]
        public async Task<ActionResult<IEnumerable<NoteDto>>> GetAllNotes()
        {
            var noteEntities = await _noteRepository.GetNotesAsync();
            return Ok(_mapper.Map<IEnumerable<NoteDto>>(noteEntities));
        }

        [HttpGet("getnotesforuser/{userid}", Name = "GetNotesForUser")]
        public async Task<ActionResult<IEnumerable<NoteDto>>> GetNotesForUser(
            int userId)
        {
            var noteEntities = await _noteRepository.GetNotesForUserAsync(userId);
            return Ok(_mapper.Map<IEnumerable<NoteDto>>(noteEntities));
        }

        [HttpGet("getnoteforuser/{userid}/note/{noteid}", Name = "GetNoteForUser")]
        public async Task<ActionResult<NoteDto>> GetNoteForUser(
            int userId, int noteId)
        {
            if (!await _userRepository.UserExistsAsync(userId))
            {
                return NotFound();
            }

            var note = await _noteRepository
                .GetNoteForUserAsync(userId, noteId);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<NoteDto>(note));
        }

        [HttpPost("createnoteforuser/{userid}", Name = "CreateNoteForUser")]
        public async Task<ActionResult<NoteDto>> CreateNoteForUser(
          int userId,
          NoteForCreationDto note)
        {
            if (!await _userRepository.UserExistsAsync(userId))
            {
                return NotFound();
            }

            var newNote = _mapper.Map<Entities.Note>(note);

            await _noteRepository.AddNoteForUserAsync(userId, newNote);

            await _userRepository.SaveChangesAsync();

            var createdNoteToReturn =
                _mapper.Map<Models.NoteDto>(newNote);

            return CreatedAtRoute("GetNoteForUser",
                 new
                 {
                     userId = userId,
                     noteId = newNote.NoteId
                 },
                 createdNoteToReturn);
        }
    }
}
