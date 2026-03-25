using System.Text.Json;

public class UserService : IUserService
{

    private readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "John Doe", FirstName = "John", LastName = "Doe" },
        new User { Id = 2, Name = "Jane Doe", FirstName = "Jane", LastName = "Doe" },
        new User { Id = 3, Name = "Alice Smith", FirstName = "Alice", LastName = "Smith" },
        new User { Id = 4, Name = "Bob Brown", FirstName = "Bob", LastName = "Brown" },
        new User { Id = 5, Name = "Charlie Davis", FirstName = "Charlie", LastName = "Davis" }
    };



    public async Task<List<User>> GetUsers(string? firstName, string? lastName)
    {
        using var client = new HttpClient(); // using disposes cclient variable, just like try , finally. use where you own it. ideally this should be in a httpfactory

        // var json = await client.GetStringAsync("https://api.example.com/users");

        // var users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        var users = _users.AsQueryable();

        // Apply filters in memory
        if (!string.IsNullOrEmpty(firstName))
            users = users.Where(u => u.FirstName == firstName);

        if (!string.IsNullOrEmpty(lastName))
            users = users.Where(u => u.LastName == lastName);


        return await Task.FromResult(users.ToList());

        // return users.OrderBy(u => u.Name).ToList();
    }

    public async Task<User?> GetUserById(int id)
    {
        var users = await GetUsers(null, null);
        return users.FirstOrDefault(u => u.Id == id);
    }
}