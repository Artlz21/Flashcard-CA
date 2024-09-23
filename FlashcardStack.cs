namespace FlashcardApp;

public class FlashcardStack {
    public int ID { get; set; }
    public string Name { get; set; } = "";
}

public class FlashcardStackDTO {
    public required string Name { get; set; }
    public List<FlashCardDTO> Flashcards { get; set; } = new();
    public List<RecordDTO> Records { get; set; } = new();
    public int NumberOfCards => Flashcards.Count;
}

public class FlashcardStackMapper {
    public FlashcardStackDTO FlashcardStackDTOMapper(FlashcardStack flashcardStack, List<FlashCardDTO> flashCards, List<RecordDTO> record) {
        return new FlashcardStackDTO {
            Name = flashcardStack.Name,
            Flashcards = flashCards,
            Records = record
        };
    }

    public FlashcardStackDTO FlashcardStackDTOMapper(FlashcardStack flashcardStack, List<FlashCardDTO> flashCards) {
        return new FlashcardStackDTO {
            Name = flashcardStack.Name,
            Flashcards = flashCards,
        };
    }
}

public class Record {
    public int ID { get; set; } 
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

    public List<RecordDTO> RecordDTOMapper(List<Record> records) {
        List<RecordDTO> recordDTOList = new();
        
        foreach (var record in records) {
            RecordDTO recordDTO = new() { 
                Total = record.Total, Correct = record.Correct, DateAndTime = record.DateAndTime
            };
            recordDTOList.Add(recordDTO);
        }
        
        return recordDTOList;
    }
}