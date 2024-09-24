namespace FlashcardApp;

public class FlashcardStack {
    public int ID { get; set; }
    public string Name { get; set; } = "";
}

public class FlashcardStackDTO(FlashcardStack stack, List<FlashcardDTO>? flashcards, List<RecordDTO>? records) {
    public string Name = stack.Name;
    public List<FlashcardDTO>? Flashcards = flashcards;
    public List<RecordDTO>? Records = records;
    public int NumberOfCards => Flashcards?.Count ?? 0;
}

// public class FlashcardStackMapper {
//     public FlashcardStackDTO FlashcardStackDTOMapper(FlashcardStack flashcardStack, List<FlashCardDTO> flashCards, List<RecordDTO> record) {
//         return new FlashcardStackDTO {
//             Name = flashcardStack.Name,
//             Flashcards = flashCards,
//             Records = record
//         };
//     }

//     public FlashcardStackDTO FlashcardStackDTOMapper(FlashcardStack flashcardStack, List<FlashCardDTO> flashCards) {
//         return new FlashcardStackDTO {
//             Name = flashcardStack.Name,
//             Flashcards = flashCards,
//         };
//     }
// }
