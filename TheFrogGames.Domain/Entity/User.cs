using System.Net.Sockets;

namespace TheFrogGames.Domain.Entity;

 public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime Date { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
    public string Province { get; set; }
    public string City { get; set; }
    public int RoleId { get; set; }


}
