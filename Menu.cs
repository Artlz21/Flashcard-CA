namespace FlashcardApp; 
public class Menu () {
    public void StartApp() {
        FlashCard FirstCard = new() { Id = 1, StackID = 1, FrontText = "First", BackText = "First"};
        FlashCard SecondCard = new() { Id = 2, StackID = 1, FrontText = "Second", BackText = "Second"};
        FlashCard ThirdCard = new() { Id = 3, StackID = 1, FrontText = "Third", BackText = "Third"};
        FlashCard FourthCard = new() { Id = 4, StackID = 2, FrontText = "Fourth", BackText = "Fourth"};
        Stacks First = new() { Id = 1, Name = "First" };
        Stacks Second = new() { Id = 2, Name = "Second" };
        Stacks Third = new() { Id = 3, Name = "Third" };

        List<Stacks> ListOfStacks = [First, Second, Third];
        List<FlashCard> ListOfFlashCards = [FirstCard, SecondCard, ThirdCard, FourthCard ];
        
        bool exitApp = false;

        while (!exitApp) {
            try {
                MainMenu();
                string mainMenuSelection = Console.ReadLine() ?? "";
                _ = int.TryParse(mainMenuSelection, out int optionSelected);
                string newStackName = "";
                string stackToDelete = "";
                string stackToAddCard = "";
                string stackToDeleteCard = "";
                string frontText = "";
                string backText = "";
                Stacks? stack; 
                List<FlashCard> flashcardsBelongingToStack;

                switch (optionSelected) {
                    case 0:
                        exitApp = true;
                        Console.Clear();
                        break;
                    case 1:
                        Console.Clear();
                        ShowListOfStacks(ListOfStacks);
                        Console.WriteLine("\nEnter a new Stack name: ");
                        newStackName = Console.ReadLine() ?? ""; 

                        if (newStackName == "" || newStackName == null) 
                            Console.WriteLine("Enter a valid name");
                        else {
                            Stacks NewStack = new() { Id = ListOfStacks.Count + 1, Name = newStackName };
                            ListOfStacks.Add(NewStack);
                            Console.WriteLine($"Stack named {newStackName} added.");
                        }
                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        if (ListOfStacks.Count == 0) {
                            Console.WriteLine("No stacks currently recorded...");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;
                        }
                        ShowListOfStacks(ListOfStacks);
                        Console.WriteLine("\nEnter a Stack name to delete: ");
                        stackToDelete = Console.ReadLine() ?? ""; 
                        stack = ListOfStacks.FirstOrDefault(stack => stack.Name == stackToDelete);

                        if (stack != null) {
                            ListOfFlashCards.RemoveAll(card => card.StackID == stack.Id);
                            ListOfStacks.Remove(stack);
                            Console.WriteLine($"Stack named {stack.Name} removed");
                        }
                        else {
                            Console.WriteLine("Could not find stack...");
                        }

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        ShowListOfStacks(ListOfStacks);
                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        if (ListOfStacks.Count == 0) {
                            Console.WriteLine("No stacks currently recorded...");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        ShowListOfStacks(ListOfStacks);
                        stackToAddCard = Console.ReadLine() ?? "";
                        if (stackToAddCard == "" || !ListOfStacks.Any(stack => stack.Name == stackToAddCard)) {
                            Console.WriteLine("Please enter a valid stack name...");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;                     
                        }

                        stack = ListOfStacks.First(stack => stack.Name == stackToAddCard);
                        Console.Clear();
                        flashcardsBelongingToStack = [];
                        foreach(var card in ListOfFlashCards) {
                            if (card.StackID == stack.Id)
                                flashcardsBelongingToStack.Add(card);
                                Console.WriteLine($"{card.Id}. {card.FrontText}");
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

                        FlashCard flashCard = new() { Id = flashcardsBelongingToStack.Count + 1, StackID = stack.Id, FrontText = frontText, BackText = backText };
                        ListOfFlashCards.Add(flashCard);
                        Console.WriteLine("Flashcard added to stack");

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
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
                        if (stackToAddCard == "" || !ListOfStacks.Any(stack => stack.Name == stackToAddCard)) {
                            Console.WriteLine("Please enter a valid stack name...");
                            Console.WriteLine("\nPress enter to continue");
                            Console.ReadLine();
                            break;                     
                        }

                        stack = ListOfStacks.First(stack => stack.Name == stackToAddCard);
                        Console.Clear();
                        flashcardsBelongingToStack = [];
                        foreach(var card in ListOfFlashCards) {
                            if (card.StackID == stack.Id)
                                flashcardsBelongingToStack.Add(card);
                                Console.WriteLine($"{card.Id}. {card.FrontText}");
                        }

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();

                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();

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

    private void ShowListOfStacks(List<Stacks> list) {
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
}


// public class Menu () {
//     private bool exitApp = false; 
//     private string mainMenuSelection = "";
//     private int optionSelected = -1;

//     // used to hold collections flashcard stacks that hold respective flashcards
//     private List<Stacks> list = [];

//     // used to handle viewing and any changes to flashcard stacks
//     private StackOperator stackOperator = new();

//     private CardOperator cardOperator = new();

//     public void StartApp() {
//         FlashCard FirstCard = new FlashCard{ Id = 1, StackID = 1, FrontText = "First", BackText = "First"};
//         FlashCard SecondCard = new FlashCard{ Id = 2, StackID = 1, FrontText = "Second", BackText = "Second"};
//         FlashCard ThirdCard = new FlashCard{ Id = 3, StackID = 1, FrontText = "Third", BackText = "Third"};
//         Stacks First = new() { Id = 1, Name = "First", Cards = [FirstCard, SecondCard, ThirdCard]};
//         Stacks Second = new() { Id = 2, Name = "Second", Cards = []};
//         list.Add(First);
//         list.Add(Second);

//         while (!exitApp) {
//             try {
//                 MainMenu();
//                 mainMenuSelection = Console.ReadLine() ?? "";
//                 _ = int.TryParse(mainMenuSelection, out optionSelected);
//                 string stackName = "";
                
//                 switch (optionSelected) {
//                     case 0:
//                         Console.Clear();
//                         exitApp = true;
//                         break;
//                     case 1:
//                         Console.Clear();
//                         ShowListOfStacks(list);
//                         stackOperator.AddStack(list);
//                         break;
//                     case 2:
//                         Console.Clear();
//                         ShowListOfStacks(list);
//                         stackOperator.DeleteStackFromList(list);
//                         break;
//                     case 3:
//                         Console.Clear();
//                         ShowListOfStacks(list);
//                         Console.WriteLine("\nPress enter to continue");
//                         Console.ReadLine();
//                         break;
//                     case 4:
//                         Console.Clear();

//                         if (list.Count > 0) {
//                             ShowListOfStacks(list);
//                             Console.WriteLine("Enter a stack name to add a card too. ");
//                             stackName = Console.ReadLine() ?? "";
//                         }
//                         else {
//                             Console.WriteLine("No stack of flashcards to add a card exists.");
//                             Console.WriteLine("Press enter to continue");
//                             Console.ReadLine();
//                             break;
//                         }

//                         cardOperator.CreateNewCard(list, stackName);
//                         break;
//                     case 5:
//                         Console.Clear();
//                         ShowListOfStacks(list);
//                         Console.WriteLine("");
//                         stackName = Console.ReadLine() ?? "";
//                         var stack = list.FirstOrDefault(stack => stack.Name == stackName);

//                         if (stack != null) {
//                             stackOperator.CardsInStack(stack);
//                             Console.WriteLine("Enter the ID of the card to delete");
//                             int.TryParse(Console.ReadLine(), out int cardID);

//                         }
//                         Console.WriteLine("\nPress enter to continue");
//                         Console.ReadLine();
//                         break;
//                     case 6:
//                         Console.Clear();
//                         Console.WriteLine("Shows table to select Stack for study session\n");
//                         Console.WriteLine("Press enter to continue");
//                         Console.ReadLine();
//                         break;
//                     case 7:
//                         Console.Clear();
//                         Console.WriteLine("Shows table for Stack to see history\n");
//                         Console.WriteLine("Press enter to continue");
//                         Console.ReadLine();
//                         break;
//                     default:
//                         Console.Clear();
//                         Console.WriteLine("Please enter a valid input\n");
//                         Console.WriteLine("Press enter to continue");
//                         Console.ReadLine();
//                         break;
//                 }
//             }
//             catch (Exception ex) {
//                 Console.WriteLine("Error: " + ex.Message);
//             }
//         }
//     }

//     public void MainMenu () {
//         Console.Clear();
//         Console.WriteLine(
//             """
//             Main Menu 

//             Select an option below
//             --------------------------
//             1. Add new Stack
//             2. Delete a Stack
//             3. View Stacks
//             4. Add new flashcard
//             5. Delete a flashcard
//             6. Begin Study Session
//             7. View past Sessions

//             0. Exit
//             --------------------------
//             """);
//     }

//     public void ShowListOfStacks (List<Stacks> list) {
//         try {
//             Console.WriteLine 
//                 ("""
//                 List of recorded Stacks
//                 --------------------------
//                 """);
//             if (list != null) {
//                 foreach(var stack in list){
//                     Console.WriteLine(stack.Name);
//                 }
//             }
//             else {
//                 Console.WriteLine("No Stacks of Flashcards currently saved");
//             }
//         }
//         catch (Exception ex) {
//             Console.WriteLine("Error: " + ex.Message); 
//         }
//     }
// }