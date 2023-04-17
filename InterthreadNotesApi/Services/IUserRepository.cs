using InterthreadNotesApi.Entities;

namespace InterthreadNotesApi.Services
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User?> GetUserAsync(int userId);
        Task AddUserAsync(User user);
        Task<bool> UserExistsAsync(int userId);
        Task<bool> SaveChangesAsync();
    }
}
