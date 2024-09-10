namespace FlashcardApp;

public class FlashCard {
    public int Id { get; set; }
    public int StackID { get; set; }
    public int CardNumber { get; set; }
    public string FrontText { get; set; } = "";
    public string BackText { get; set; } = "";
    public bool? Marker { get; set; } = null;
}

public class FlashCardDTO {
    public int Number { get; set; }
    public string FrontText { get; set; } = "";
    public string BackText { get; set;} = "";
    public bool? Marker { get; set; } = null;
}

public class FlashCardMapper {
    public List<FlashCardDTO> FlashCardDTOMapper(List<FlashCard> flashCards) {
        List<FlashCardDTO> flashCardDTOList = new();
        
        int count = 1;
        foreach (var flashCard in flashCards) {
            FlashCardDTO flashCardDTO = new FlashCardDTO { 
                Number = count, FrontText = flashCard.FrontText, BackText = flashCard.BackText, Marker = null
            };
            flashCardDTOList.Add(flashCardDTO);
        }
        
        return flashCardDTOList;
    }

    public FlashCardDTO FlashCardDTOMapper(FlashCard flashCard) {
        return new FlashCardDTO { 
            Number = flashCard.CardNumber, FrontText = flashCard.FrontText, BackText = flashCard.BackText 
        };
    }
}