namespace FlashcardApp;


public class CardManager () {
    public List<FlashCardDTO> GetCardsBelongingToStack(FlashcardStackDTO stack) {
        List<FlashCardDTO> ListOfCards = [];

        foreach (var card in stack.Flashcards) {
            ListOfCards.Add(card);
        }

        return ListOfCards;
    }

    public FlashCardDTO? CreateNewCard() {
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

        return new FlashCardDTO { FrontText = frontText, BackText = backText };
    }

    public bool DeleteFlashcard(FlashcardStackDTO stack) {
        Console.WriteLine("\nEnter a card number to delete a card");
        if (!int.TryParse(Console.ReadLine(), out int cardNumber) || cardNumber <= 0) {
            Console.WriteLine("Please enter a valid number...");
            return false;
        }

        FlashCardDTO? flashcardToDelete = stack.Flashcards.ElementAt(cardNumber - 1);

        if (flashcardToDelete != null) {
            stack.Flashcards.Remove(flashcardToDelete);
            Console.WriteLine($"Flashcard number {cardNumber} has been removed.");
            return true;
        } 
        else {
            Console.WriteLine("Card not found. Please enter a valid card number.");
            return false;
        }
    }

    public void StartQuiz(FlashcardStackDTO stack) {
        Console.Clear();
        foreach (var card in stack.Flashcards) {
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

        int total = stack.NumberOfCards;
        int correct = stack.Flashcards.Count(card => card.Marker == true);
        DateTime dateTime = DateTime.Now;

        stack.Records.Add(new RecordDTO { Correct = correct, Total = total, DateAndTime = dateTime});

        Console.WriteLine($"You got {correct} out of {total}");
    }
}