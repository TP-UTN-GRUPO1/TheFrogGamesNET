namespace TheFrogGames.Domain.Entity;

public class Platform : BaseEntity
{
    public string? Name { get; set; } = string.Empty;

    public ICollection<Game> Games { get; set; } = new List<Game>();
}
