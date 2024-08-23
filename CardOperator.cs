namespace FlashcardApp;

public class CardOperator () {
    private FlashCard flashcard = new();
    private string frontText = "";
    private string backText = "";

    public void CreateNewCard () {
        Console.WriteLine("Enter the Front text of the card: ");
        frontText = Console.ReadLine() ?? "";
        Console.WriteLine("Enter the Back text of the card: ");
        backText = Console.ReadLine() ?? "";
    }
}