using System.Text.Json;

public class UserService : IUserService
{
    public async Task<List<User>> GetUsers(string? firstName, string? lastName)
    {
        using var client = new HttpClient();

        var json = await client.GetStringAsync("https://api.example.com/users");

        var users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();

        // Apply filters in memory
        if (!string.IsNullOrEmpty(firstName))
            users = users.Where(u => u.FirstName == firstName).ToList();

        if (!string.IsNullOrEmpty(lastName))
            users = users.Where(u => u.LastName == lastName).ToList();

        return users.OrderBy(u => u.Name).ToList();
    }

    public async Task<User?> GetUserById(int id)
    {
        var users = await GetUsers(null, null);
        return users.FirstOrDefault(u => u.Id == id);
    }
}