namespace FlashcardApp;

public class FlashCard {
    public int Id { get; set; }
    public int ForeignKey { get; set; }
    public string FrontText { get; set; } = "";
    public string BackText { get; set; } = "";
    public int CardNumber { get; set; }
    public bool? Marker { get; set; }
}