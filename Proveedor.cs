public class Proveedor
{
    public int Id { get; set; }
    public string SupplierId { get; set; }
    public Dictionary<string, string> Details { get; set; } = new();
    public string Status { get; set; } = "activo";
}