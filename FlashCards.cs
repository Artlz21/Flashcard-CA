namespace FlashcardApp;

public class FlashCard {
    public int Id { get; set; }
    public int StackID { get; set; }
    public string FrontText { get; set; } = "";
    public string BackText { get; set; } = "";
    public bool? Marker { get; set; } = null;
}