using Microsoft.VisualBasic;

namespace FlashcardApp; 
public class Menu () {
    private StackManager stackManager = new();
    private CardManager cardManager = new();
    public void StartApp() {
        // Sample data to work with
        FlashCard FirstCard = new() { Id = 1, StackID = 1, CardNumber = 1, FrontText = "First", BackText = "First"};
        FlashCard SecondCard = new() { Id = 2, StackID = 1, CardNumber = 2, FrontText = "Second", BackText = "Second"};
        FlashCard ThirdCard = new() { Id = 3, StackID = 1, CardNumber = 3, FrontText = "Third", BackText = "Third"};
        FlashCard FourthCard = new() { Id = 4, StackID = 2, CardNumber = 1, FrontText = "Fourth", BackText = "Fourth"};
        FlashcardStack First = new() { Id = 1, Name = "First", Records = [] };
        FlashcardStack Second = new() { Id = 2, Name = "Second", Records = [] };
        FlashcardStack Third = new() { Id = 3, Name = "Third", Records = [] };

        List<FlashcardStack> ListOfStacks = [First, Second, Third];
        List<FlashCard> ListOfFlashCards = [FirstCard, SecondCard, ThirdCard, FourthCard ];
        
        // Condition and loop keeping app running 
        bool exitApp = false;
        while (!exitApp) {
            try {
                string stackToDeleteCard = "";
                string stackToSelect = ""; 
                string frontText = "";
                string backText = "";
                string answer = "";
                int cardNumber = 0;
                int correct = 0;
                int total = 0;
                FlashCard? flashcardToDelete;
                FlashcardStack? stack; 
                List<FlashCard> flashcardsBelongingToStack;

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

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    // Deletes an existing stack from list
                    case 2:
                        if (CheckListIsFilled(ListOfStacks)) break;

                        ShowListOfStacks(ListOfStacks);
                        Console.WriteLine("\nEnter a Stack name to delete: ");
                        stack = stackManager.GetSelectedStack(ListOfStacks);
                        if (stack == null) {
                            Console.WriteLine("Could not find stack...");
                            Console.WriteLine("\nPress enter to continue");
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
                        if (CheckListIsFilled(ListOfStacks)) break;

                        ShowListOfStacks(ListOfStacks);
                        stack = stackManager.GetSelectedStack(ListOfStacks);
                        if (stack == null) {
                            Console.WriteLine("Could not find stack...");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        Console.Clear();
                        flashcardsBelongingToStack = cardManager.GetCardsBelongingToStack(stack, ListOfFlashCards);
                        foreach(var card in flashcardsBelongingToStack) {
                            Console.WriteLine($"{card.CardNumber}. {card.FrontText}");
                        }

                        Console.WriteLine("\nEnter the Front text of card");
                        frontText = Console.ReadLine() ?? "";
                        if(frontText == "") {
                            Console.WriteLine("Please enter a front text");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("\nEnter the Back text of card");
                        backText = Console.ReadLine() ?? "";
                        if(backText == "") {
                            Console.WriteLine("Please enter a back text");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        FlashCard flashCard = new() { Id = flashcardsBelongingToStack.Count + 1, StackID = stack.Id, CardNumber = flashcardsBelongingToStack.Count + 1, FrontText = frontText, BackText = backText };
                        ListOfFlashCards.Add(flashCard);
                        Console.WriteLine("Flashcard added to stack");

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    // Deletes a card from an existing stack
                    case 5:
                        Console.Clear();
                        if (ListOfStacks.Count == 0) {
                            Console.WriteLine("No stacks currently recorded...");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        ShowListOfStacks(ListOfStacks);
                        stackToDeleteCard = Console.ReadLine() ?? "";
                        if (stackToDeleteCard == "" || !ListOfStacks.Any(stack => stack.Name == stackToDeleteCard)) {
                            Console.WriteLine("Please enter a valid stack name...");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;                     
                        }

                        stack = ListOfStacks.First(stack => stack.Name == stackToDeleteCard);
                        Console.Clear();
                        flashcardsBelongingToStack = [];
                        foreach(var card in ListOfFlashCards) {
                            if (card.StackID == stack.Id) {
                                flashcardsBelongingToStack.Add(card);
                                Console.WriteLine($"{card.CardNumber}. {card.FrontText}");
                            }
                        }

                        Console.WriteLine("Enter the card number to select a card");
                        _ = int.TryParse(Console.ReadLine(), out cardNumber);
                        if (cardNumber == 0) {
                            Console.WriteLine("Please enter a valid number...");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        flashcardToDelete = flashcardsBelongingToStack.FirstOrDefault(card => card.CardNumber == cardNumber);

                        if (flashcardToDelete != null) {
                            ListOfFlashCards.Remove(flashcardToDelete);
                            Console.WriteLine($"Flashcard with ID {flashcardToDelete.Id} has been removed.");
                        } 
                        else {
                            Console.WriteLine("Card not found. Please enter a valid card number.");
                        }

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    // Starts a quiz with cards from a selected stack
                    case 6:
                        Console.Clear();
                        if (ListOfStacks.Count == 0) {
                            Console.WriteLine("No stacks currently recorded...");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        ShowListOfStacks(ListOfStacks);
                        stackToSelect = Console.ReadLine() ?? "";
                        if (stackToSelect == "" || !ListOfStacks.Any(stack => stack.Name == stackToSelect)) {
                            Console.WriteLine("Please enter a valid stack name...");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;                     
                        }

                        stack = ListOfStacks.First(stack => stack.Name == stackToSelect);
                        flashcardsBelongingToStack = [];
                        foreach (var card in ListOfFlashCards) {
                            if (card.StackID == stack.Id) {
                                flashcardsBelongingToStack.Add(card);
                            }
                        }

                        Console.Clear();
                        foreach (var card in flashcardsBelongingToStack) {
                            Console.WriteLine(card.FrontText);
                            answer = Console.ReadLine() ?? "";

                            if (answer == card.BackText) {
                                card.Marker = true;
                            }
                            else {
                                card.Marker = false;
                            }
                            Console.Clear();
                        }

                        total = flashcardsBelongingToStack.Count;
                        correct = flashcardsBelongingToStack.Count(card => card.Marker == true);
                        DateTime dateTime = DateTime.Now;

                        stack.Records.Add(new Record { Correct = correct, Total = total, DateAndTime = dateTime});

                        Console.WriteLine($"You got {correct} out of {total}");

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    // Shows record of scores from selected stack
                    case 7:
                        Console.Clear();
                        if (ListOfStacks.Count == 0) {
                            Console.WriteLine("No stacks currently recorded...");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        ShowListOfStacks(ListOfStacks);
                        stackToSelect = Console.ReadLine() ?? "";
                        if (stackToSelect == "" || !ListOfStacks.Any(stack => stack.Name == stackToSelect)) {
                            Console.WriteLine("Please enter a valid stack name...");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;                     
                        }

                        stack = ListOfStacks.First(stack => stack.Name == stackToSelect);
                        if (stack.Records == null) {
                            Console.WriteLine("Please enter a valid stack name...");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break; 
                        }

                        Console.Clear();
                        foreach (var record in stack.Records) {
                            int count = 1;
                            Console.WriteLine($"Record for {stack.Name}");
                            Console.WriteLine($"{count}. Date: {record.DateAndTime}, Score: {record.Correct} / {record.Total}");
                        }

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
            4. Add new flashcard
            5. Delete a flashcard
            6. Begin Study Session
            7. View past Sessions

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
        if (list.Count > 0 || list != null) return false;

        Console.WriteLine("No stacks currently recorded...");
        Console.WriteLine("\nPress enter to continue");
        Console.ReadLine();
        return true;
    }
}