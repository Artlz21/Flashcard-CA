using Microsoft.VisualBasic;

namespace FlashcardApp; 
public class Menu () {
    private StackManager stackManager = new();
    private CardManager cardManager = new();
    public void StartApp() {
        // Sample data to work with. Need to reconfigure to align with new DTO design for use.
        FlashCard FirstCard = new() { Id = 1, StackID = 1, CardNumber = 1, FrontText = "First", BackText = "First"};
        FlashCard SecondCard = new() { Id = 2, StackID = 1, CardNumber = 2, FrontText = "Second", BackText = "Second"};
        FlashCard ThirdCard = new() { Id = 3, StackID = 1, CardNumber = 3, FrontText = "Third", BackText = "Third"};
        FlashCard FourthCard = new() { Id = 4, StackID = 2, CardNumber = 1, FrontText = "Fourth", BackText = "Fourth"};
        FlashcardStack First = new() { Id = 1, Name = "First" };
        FlashcardStack Second = new() { Id = 2, Name = "Second" };
        FlashcardStack Third = new() { Id = 3, Name = "Third" };
        List<FlashcardStack> ListOfStacks = [First, Second, Third];
        List<FlashCard> ListOfFlashCards = [FirstCard, SecondCard, ThirdCard, FourthCard ];
        FlashcardStack? stack; 
        List<FlashCard> flashcardsBelongingToStack;
        
        // Condition and loop keeping app running 
        /*
        Need to recofig each use of stacks so as to use new DTO design for each method for better practice.
        */
        bool exitApp = false;
        while (!exitApp) {
            try {
                // Main menu user sees and selects option at
                MainMenu();
                string mainMenuSelection = Console.ReadLine() ?? "";
                _ = int.TryParse(mainMenuSelection, out int optionSelected);

                switch (optionSelected) {
                    // Ends app
                    case 0:
                        exitApp = true;
                        Console.Clear();
                        break;
                    // Adds new stack to list
                    case 1:
                        Console.Clear();
                        ShowListOfStacks(ListOfStacks);
                        stackManager.AddNewStack(ListOfStacks);

                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    // Deletes an existing stack from list
                    case 2:
                        if (CheckListIsFilled(ListOfStacks)) break;

                        ShowListOfStacks(ListOfStacks);
                        Console.WriteLine("\nEnter a Stack name to delete: ");
                        stack = stackManager.GetSelectedStack(ListOfStacks);
                        if (stack == null) {
                            Console.WriteLine("\nCould not find stack...");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        stackManager.DeleteStack(ListOfStacks, ListOfFlashCards, stack);

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    // Shows list of current stacks
                    case 3:
                        Console.Clear();
                        ShowListOfStacks(ListOfStacks);
                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    // Adds a new card to existing stack
                    case 4:            
                        // Check if list of stacks is not empty            
                        if (CheckListIsFilled(ListOfStacks)) break;

                        // Show list of stacks for user to select one to add card too
                        ShowListOfStacks(ListOfStacks);
                        stack = stackManager.GetSelectedStack(ListOfStacks);
                        if (stack == null) {
                            Console.WriteLine("\nCould not find stack...");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        // Gets all cards belonging to selected stack clears screen and shows as a list
                        Console.Clear();
                        flashcardsBelongingToStack = cardManager.GetCardsBelongingToStack(stack, ListOfFlashCards);
                        foreach(var card in flashcardsBelongingToStack) {
                            Console.WriteLine($"{card.CardNumber}. {card.FrontText}");
                        }

                        // Prompts user to add front and back side of a new card
                        FlashCard? flashCard = cardManager.CreateNewCard(flashcardsBelongingToStack, stack);

                        if (flashCard == null) {
                            Console.WriteLine("\nCard was not added...");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        // Create new flashcard object using front and back text and other components and add to list of cards
                        ListOfFlashCards.Add(flashCard);
                        Console.WriteLine("\nFlashcard added to stack");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    // Deletes a card from an existing stack
                    case 5:
                        // Check if list of stacks is not empty            
                        if (CheckListIsFilled(ListOfStacks)) break;

                        // Show list of stacks for user to select one to add card too
                        ShowListOfStacks(ListOfStacks);
                        stack = stackManager.GetSelectedStack(ListOfStacks);
                        if (stack == null) {
                            Console.WriteLine("\nCould not find stack...");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        // Gets all cards belonging to selected stack clears screen and shows as a list
                        Console.Clear();
                        flashcardsBelongingToStack = cardManager.GetCardsBelongingToStack(stack, ListOfFlashCards);
                        foreach(var card in flashcardsBelongingToStack) {
                            Console.WriteLine($"{card.CardNumber}. {card.FrontText}");
                        }

                        if (!cardManager.DeleteFlashcard(flashcardsBelongingToStack, ListOfFlashCards)) {
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    case 6:
                        break;
                    // Starts a quiz with cards from a selected stack
                    case 7:
                        // Check if list of stacks is not empty            
                        if (CheckListIsFilled(ListOfStacks)) break;

                        // Show list of stacks for user to select one to add card too
                        ShowListOfStacks(ListOfStacks);
                        stack = stackManager.GetSelectedStack(ListOfStacks);
                        if (stack == null) {
                            Console.WriteLine("\nCould not find stack...");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        // Retrieve all cards belonging to selected stack
                        flashcardsBelongingToStack = cardManager.GetCardsBelongingToStack(stack, ListOfFlashCards);

                        cardManager.StartQuiz(flashcardsBelongingToStack, stack);

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    // Shows record of scores from selected stack
                    case 8:
                        // Check if list of stacks is not empty            
                        if (CheckListIsFilled(ListOfStacks)) break;

                        // Show list of stacks for user to select one to add card too
                        ShowListOfStacks(ListOfStacks);
                        stack = stackManager.GetSelectedStack(ListOfStacks);
                        if (stack == null) {
                            Console.WriteLine("\nCould not find stack...");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        stackManager.ShowRecord(stack);

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("\nPlease select an option from menu.");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }

    private void MainMenu () {
        Console.Clear();
        Console.WriteLine(
            """
            Main Menu 

            Select an option below
            --------------------------
            1. Add new Stack
            2. Delete a Stack
            3. View Stacks
            4. Add a new flashcard
            5. Delete a flashcard
            6. View flashcards
            7. Begin Study Session
            8. View past Sessions

            0. Exit
            --------------------------
            """);
    }

    private void ShowListOfStacks(List<FlashcardStack> list) {
        try {
            Console.WriteLine 
                ("""
                List of recorded Stacks
                --------------------------
                """);
            if (list != null) {
                foreach(var stack in list){
                    Console.WriteLine(stack.Name);
                }
            }
            else {
                Console.WriteLine("No Stacks of Flashcards currently saved");
            }
        }
        catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message); 
        }
    }

    private bool CheckListIsFilled(List<FlashcardStack> list) {
        Console.Clear();
        if (list.Count == 0 || list == null) {
            Console.WriteLine("No stacks currently recorded...");
            Console.WriteLine("\nPress enter to continue");
            Console.ReadLine();
            return true;
        }

        return false;
    }
}