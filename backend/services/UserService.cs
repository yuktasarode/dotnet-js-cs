using System.Text.Json;

public class UserService : IUserService
{
    public async Task<List<User>> GetUsers()
    {
        using var client = new HttpClient();

        var json = await client.GetStringAsync("https://api.example.com/users");

        var users = JsonSerializer.Deserialize<List<User>>(json);

        // Sort by name
        return users.OrderBy(u => u.Name).ToList();
    }

    public async Task<User?> GetUserById(int id)
    {
        var users = await GetUsers();
        return users.FirstOrDefault(u => u.Id == id);
    }
}