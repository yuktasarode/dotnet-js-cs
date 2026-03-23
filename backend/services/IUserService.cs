public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<User?> GetUserById(int id);
}