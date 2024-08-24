namespace FlashcardApp;

public class Stacks {
    public int Id { get; set; }
    public int ForeignKey { get; set; }
    public string Name { get; set; } = "";
    public SortedSet<FlashCard>? Cards { get; set; }
}