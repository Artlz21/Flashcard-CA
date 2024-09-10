namespace FlashcardApp;

public class FlashcardStack {
    public int Id { get; set; }
    public string Name { get; set; } = "";
}

public class FlashcardStackDTO {
    public required string Name { get; set; }
    public List<FlashCardDTO> Flashcards { get; set; } = new();
    public RecordDTO? Records { get; set; }
    public int NumberOfCards => Flashcards.Count;
}

public class FlashcardStackMapper {
    public FlashcardStackDTO flashcardStackDTOMapper(FlashcardStack flashcardStack, List<FlashCardDTO> flashCards, RecordDTO record) {
        return new FlashcardStackDTO {
            Name = flashcardStack.Name,
            Flashcards = flashCards,
            Records = record
        };
    }
}

public class Record {
    public int Id { get; set; } 
    public int StackID { get; set; }
    public int Total { get; set; }
    public int Correct { get; set; }
    public DateTime DateAndTime { get; set; }
}

public class RecordDTO {
    public int Total { get; set; }
    public int Correct { get; set; }
    public DateTime DateAndTime { get; set; }
}

public class RecordMapper {
    public RecordDTO RecordDTOMapper(Record record) {
        return new RecordDTO{
            Total = record.Total,
            Correct = record.Correct,
            DateAndTime = record.DateAndTime
        };
    }
}