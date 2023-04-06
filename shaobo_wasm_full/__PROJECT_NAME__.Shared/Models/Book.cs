namespace __PROJECT_NAME__.Shared.Models;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Author { get; set; } = default!;
    public decimal Price { get; set; }
}
