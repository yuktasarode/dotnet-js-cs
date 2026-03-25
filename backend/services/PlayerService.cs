using System.Text.Json;

public class PlayerService:IPlayerService

{
    private const string DataUrl = "https://raw.githubusercontent.com/algolia/datasets/refs/heads/master/basketball/nba-players.json";

    public async Task<List<Player>> GetPlayers()
    {
        using var client = new HttpClient();
        var json =await client.GetFromJsonAsync<List<Player>>(DataUrl);
        return json ?? new List<Player>();

    }

}