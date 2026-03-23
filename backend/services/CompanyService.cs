using System.Text.Json;

public class CompanyService : ICompanyService
{
    public async Task<List<Company>> GetCompanies()
    {
        using var client = new HttpClient();

        var json = await client.GetStringAsync("https://api.example.com/companies");

        var companies = JsonSerializer.Deserialize<List<Company>>(json);

        // Sort by name
        return companies.OrderBy(c => c.Name).ToList();
    }
}