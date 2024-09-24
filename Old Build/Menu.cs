using Microsoft.VisualBasic;

namespace FlashcardApp; 
public class Menu (string connectionString) {
    private StackManager stackManager = new();
    private CardManager cardManager = new();
    private FlashcardServices flashcardServices = new(connectionString);
    public void StartApp() {
        FlashcardStackDTO? stack; 
        List<FlashCardDTO> flashcardsBelongingToStack;

        List<FlashcardStackDTO>? FlashCardStackDTOs = flashcardServices.GetAllStackDTOs();

        int count;
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
                        ShowListOfStacks(FlashCardStackDTOs);
                        stackManager.AddNewStack(FlashCardStackDTOs);

                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    // Deletes an existing stack from list
                    case 2:
                        if (CheckListIsFilled(FlashCardStackDTOs)) break;

                        ShowListOfStacks(FlashCardStackDTOs);
                        Console.WriteLine("\nEnter a Stack name to delete: ");
                        stack = stackManager.GetSelectedStack(FlashCardStackDTOs);
                        if (stack == null) {
                            Console.WriteLine("\nCould not find stack...");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        stackManager.DeleteStack(FlashCardStackDTOs, stack);

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    // Shows list of current stacks
                    case 3:
                        Console.Clear();
                        ShowListOfStacks(FlashCardStackDTOs);
                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    // Adds a new card to existing stack
                    case 4:            
                        // Check if list of stacks is not empty            
                        if (CheckListIsFilled(FlashCardStackDTOs)) break;

                        // Show list of stacks for user to select one to add card too
                        ShowListOfStacks(FlashCardStackDTOs);
                        Console.WriteLine("Enter a stack name to select");
                        stack = stackManager.GetSelectedStack(FlashCardStackDTOs);
                        if (stack == null) {
                            Console.WriteLine("\nCould not find stack...");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        // Gets all cards belonging to selected stack clears screen and shows as a list
                        Console.Clear();
                        flashcardsBelongingToStack = cardManager.GetCardsBelongingToStack(stack);
                        count = 1;
                        foreach(var card in flashcardsBelongingToStack) {
                            Console.WriteLine($"{count}. {card.FrontText}");
                            count++;
                        }

                        // Prompts user to add front and back side of a new card
                        FlashCardDTO? flashCard = cardManager.CreateNewCard();

                        if (flashCard == null) {
                            Console.WriteLine("\nCard was not added...");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        // Create new flashcard object using front and back text and other components and add to list of cards
                        stack.Flashcards.Add(flashCard);
                        Console.WriteLine("\nFlashcard added to stack");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    // Deletes a card from an existing stack
                    case 5:
                        // Check if list of stacks is not empty            
                        if (CheckListIsFilled(FlashCardStackDTOs)) break;

                        // Show list of stacks for user to select one to add card too
                        ShowListOfStacks(FlashCardStackDTOs);
                        stack = stackManager.GetSelectedStack(FlashCardStackDTOs);
                        if (stack == null) {
                            Console.WriteLine("\nCould not find stack...");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        // Gets all cards belonging to selected stack clears screen and shows as a list
                        Console.Clear();
                        flashcardsBelongingToStack = cardManager.GetCardsBelongingToStack(stack);
                        count = 1;
                        foreach(var card in flashcardsBelongingToStack) {
                            Console.WriteLine($"{count}. {card.FrontText}");
                            count++;
                        }

                        if (!cardManager.DeleteFlashcard(stack)) {
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    case 6:
                        // Check if list of stacks is not empty            
                        if (CheckListIsFilled(FlashCardStackDTOs)) break;

                        // Show list of stacks for user to select one to add card too
                        ShowListOfStacks(FlashCardStackDTOs);
                        stack = stackManager.GetSelectedStack(FlashCardStackDTOs);
                        if (stack == null) {
                            Console.WriteLine("\nCould not find stack...");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        count = 1;
                        foreach (var card in stack.Flashcards) {
                            Console.WriteLine($"{count}. {card.FrontText}");
                            count++;
                        }
                        break;
                    // Starts a quiz with cards from a selected stack
                    case 7:
                        // Check if list of stacks is not empty            
                        if (CheckListIsFilled(FlashCardStackDTOs)) break;

                        // Show list of stacks for user to select one to add card too
                        ShowListOfStacks(FlashCardStackDTOs);
                        stack = stackManager.GetSelectedStack(FlashCardStackDTOs);
                        if (stack == null) {
                            Console.WriteLine("\nCould not find stack...");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        // Retrieve all cards belonging to selected stack
                        flashcardsBelongingToStack = cardManager.GetCardsBelongingToStack(stack);

                        cardManager.StartQuiz(stack);

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    // Shows record of scores from selected stack
                    case 8:
                        // Check if list of stacks is not empty            
                        if (CheckListIsFilled(FlashCardStackDTOs)) break;

                        // Show list of stacks for user to select one to add card too
                        ShowListOfStacks(FlashCardStackDTOs);
                        stack = stackManager.GetSelectedStack(FlashCardStackDTOs);
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

    private void ShowListOfStacks(List<FlashcardStackDTO>? list) {
        try {
            Console.WriteLine 
                ("""
                List of recorded Stacks
                --------------------------
                """);
            if (list != null) {
                int count = 1;
                foreach(var stack in list){
                    Console.WriteLine($"{count}. {stack.Name}");
                    count++;
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

    private bool CheckListIsFilled(List<FlashcardStackDTO> list) {
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