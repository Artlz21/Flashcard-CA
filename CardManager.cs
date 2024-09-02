namespace FlashcardApp;

public class CardManager () {
    public List<FlashCard> GetCardsBelongingToStack(FlashcardStack stack, List<FlashCard> list) {
        List<FlashCard> ListOfCards = [];

        foreach (var card in list) {
            if(card.StackID == stack.Id) ListOfCards.Add(card);
        }

        return ListOfCards;
    }
}