namespace FlashcardApp;

public class Flashcard {
    public int ID { get; set; }
    public int StackID { get; set; }
    public string FrontText { get; set; } = "";
    public string BackText { get; set; } = "";
    public bool? Marker { get; set; } = null;
}

public class FlashcardDTO(Flashcard flashcard) {
    public string FrontText = flashcard.FrontText;
    public string BackText = flashcard.BackText;
    public bool? Marker = flashcard.Marker;
}

// public class FlashCardMapper {
//     public List<FlashCardDTO> FlashCardDTOMapper(List<Flashcard> flashCards) {
//         List<FlashCardDTO> flashCardDTOList = new();
        
//         foreach (var flashCard in flashCards) {
//             FlashCardDTO flashCardDTO = new FlashCardDTO { 
//                 FrontText = flashCard.FrontText, BackText = flashCard.BackText, Marker = null
//             };
//             flashCardDTOList.Add(flashCardDTO);
//         }
        
//         return flashCardDTOList;
//     }

//     public FlashCardDTO FlashCardDTOMapper(Flashcard flashCard) {
//         return new FlashCardDTO { 
//             FrontText = flashCard.FrontText, BackText = flashCard.BackText 
//         };
//     }
// }