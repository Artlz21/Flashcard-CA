namespace FlashcardApp;

public class Stack {
    public int Id { get; set; }
    public int ForeignKey { get; set; }
    public string Name { get; set; } = "";
    public List<object>? Cards { get; set; }
}