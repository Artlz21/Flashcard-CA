namespace FlashcardApp;

public class FlashcardStack {
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public required List<Record> Records { get; set; }
}

public class Record {
    public int Total { get; set; }
    public int Correct { get; set; }
    public DateTime DateAndTime{ get; set; }
}