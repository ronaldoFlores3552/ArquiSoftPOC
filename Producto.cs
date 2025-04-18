public class Producto
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public string Name { get; set; }
    public string SupplierId { get; set; }
    public Dictionary<string, string> LifecycleData { get; set; } = new() { { "status", "creado" } };
}