namespace FlashcardApp;

public class CardOperator () {

    public void CreateNewCard (List<Stacks> list, string stackName) {
        try {
            FlashCard flashcard = new();
            string frontText = "";
            string backText = "";

            Console.WriteLine("Enter the Front text of the card: ");
            frontText = Console.ReadLine() ?? "";
            Console.WriteLine("Enter the Back text of the card: ");
            backText = Console.ReadLine() ?? "";

            Stacks? StackToAddCard = list.FirstOrDefault(stack => stack.Name == stackName);


            if (StackToAddCard != null) {
                flashcard.Id = StackToAddCard.Cards != null ? StackToAddCard.Cards.Count + 1 : flashcard.Id = 1;
                flashcard.FrontText = frontText;
                flashcard.BackText = backText;

                StackToAddCard.Cards = [flashcard];
                
                Console.WriteLine("Flashcard added successfully.");
            }
            else {
                Console.WriteLine("Stack not found...");
            }
        }
        catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally {
            Console.WriteLine("Press enter to continue ");
            Console.ReadLine();
        }
    }
}