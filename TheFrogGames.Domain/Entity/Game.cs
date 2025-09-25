namespace TheFrogGames.Domain.Entity;

public class Game
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Developer { get; set; }
    public string ImageUrl { get; set; }
    public int Rating { get; set; }
    public Boolean Available { get; set; }
    public int Sold { get; set; }
}
