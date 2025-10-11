namespace TheFrogGames.Contracts.User.Response;

public class UserResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime Date { get; set; }
    public bool IsActive { get; set; }
}
