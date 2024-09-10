namespace FlashcardApp;

/*
Need to rework to use new DTO design for better practice to include business logic. 
*/
public class CardManager () {
    public List<FlashCard> GetCardsBelongingToStack(FlashcardStack stack, List<FlashCard> list) {
        List<FlashCard> ListOfCards = [];

        foreach (var card in list) {
            if(card.StackID == stack.Id) ListOfCards.Add(card);
        }

        return ListOfCards;
    }

    public FlashCard? CreateNewCard(List<FlashCard> flashcardsBelongingToStack, FlashcardStack stack) {
        Console.WriteLine("\nEnter the Front text of card");
        string frontText = Console.ReadLine() ?? "";
        if(frontText == "") {
            Console.WriteLine("Please enter a front text");
            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();
            return null;
        }
        Console.WriteLine("\nEnter the Back text of card");
        string backText = Console.ReadLine() ?? "";
        if(backText == "") {
            Console.WriteLine("Please enter a back text");
            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();
            return null;
        }

        FlashCard flashCard = new() { Id = flashcardsBelongingToStack.Count + 1, StackID = stack.Id, CardNumber = flashcardsBelongingToStack.Count + 1, FrontText = frontText, BackText = backText };

        return flashCard;
    }

    public bool DeleteFlashcard(List<FlashCard> flashcardsBelongingToStack, List<FlashCard> ListOfFlashCards) {
        Console.WriteLine("\nEnter a card number to delete a card");
        if (!int.TryParse(Console.ReadLine(), out int cardNumber) || cardNumber <= 0) {
            Console.WriteLine("Please enter a valid number...");
            return false;
        }

        FlashCard? flashcardToDelete = flashcardsBelongingToStack.FirstOrDefault(card => card.CardNumber == cardNumber);

        if (flashcardToDelete != null) {
            ListOfFlashCards.Remove(flashcardToDelete);
            flashcardsBelongingToStack.Remove(flashcardToDelete);
            Console.WriteLine($"Flashcard with ID {flashcardToDelete.Id} has been removed.");

            int count = 1;
            foreach (var card in flashcardsBelongingToStack) {
                card.CardNumber = count;
                count++;
            }
            return true;
        } 
        else {
            Console.WriteLine("Card not found. Please enter a valid card number.");
            return false;
        }
    }

    public void StartQuiz(List<FlashCard> flashcardsBelongingToStack, FlashcardStack stack) {
        Console.Clear();
        foreach (var card in flashcardsBelongingToStack) {
            Console.WriteLine(card.FrontText);
            string answer = Console.ReadLine() ?? "";

            if (answer == card.BackText) {
                card.Marker = true;
            }
            else {
                card.Marker = false;
            }
            Console.Clear();
        }

        int total = flashcardsBelongingToStack.Count;
        int correct = flashcardsBelongingToStack.Count(card => card.Marker == true);
        DateTime dateTime = DateTime.Now;

        stack.AddNewRecord(new Record(correct, total, dateTime));

        Console.WriteLine($"You got {correct} out of {total}");

    }
}