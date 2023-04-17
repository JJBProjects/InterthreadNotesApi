using InterthreadNotesApi.DbContexts;
using InterthreadNotesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterthreadNotesApi.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// A user is created with generated id
        /// </summary>
        /// <param name="user">The populated user object</param>
        public async Task AddUserAsync(User user)
        {
            if(user != null)
            {
                _context.Users.Add(user);
            }
        }

        /// <summary>
        /// Returns a single user given the specified user id
        /// </summary>
        /// <param name="userId">The unique identifier of the user</param>
        /// <returns>Single user object</returns>
        public async Task<User?> GetUserAsync(int userId)
        {
            return await _context.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Returns a list of all users in the database
        /// </summary>
        /// <returns>List of User object</returns>
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.OrderBy(x => x.UserId).ToListAsync();
        }

        /// <summary>
        /// Checks if a user with the specified Id already exists in the database
        /// </summary>
        /// <param name="userId">The unique identifier of the use</param>
        /// <returns>true if user exists</returns>
        public async Task<bool> UserExistsAsync(int userId)
        {
            return await _context.Users.AnyAsync(x => x.UserId == userId);
        }

        /// <summary>
        /// Commits changes to database, any database identites are populated
        /// </summary>
        /// <returns>true if commit was successful</returns>
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
