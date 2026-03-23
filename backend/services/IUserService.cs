public interface IUserService
{
    Task<List<User>> GetUsers(string? firstName, string? lastName);
    Task<User?> GetUserById(int id);
}