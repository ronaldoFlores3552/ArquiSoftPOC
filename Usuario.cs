public class Usuario
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Dictionary<string, string> ProfileData { get; set; } = new();
}