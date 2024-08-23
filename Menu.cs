namespace FlashcardApp; 

public class Menu () {
    private bool exitApp = false; 
    private string mainMenuSelection = "";
    private int optionSelected = -1;

    // used to hold collections flashcard stacks that hold respective flashcards
    private SortedSet<Stacks> list = [];

    // used to handle viewing and any changes to flashcard stacks
    private StackOperator stackOperator = new();

    private CardOperator cardOperator= new();

    public void StartApp() {
        while (!exitApp) {
            try {
                MainMenu();
                mainMenuSelection = Console.ReadLine() ?? "";
                _ = int.TryParse(mainMenuSelection, out optionSelected);
                
                switch (optionSelected) {
                    case 0:
                        Console.Clear();
                        exitApp = true;
                        break;
                    case 1:
                        Console.Clear();
                        stackOperator.AddStack(list);
                        break;
                    case 2:
                        Console.Clear();
                        stackOperator.DeleteStackFromList(list);
                        break;
                    case 3:
                        Console.Clear();
                        string stackName = "";

                        if (list.Count > 0) {
                            stackOperator.ShowListOfStacks(list);
                            Console.WriteLine("Enter a stack name to add a card too. ");
                            stackName = Console.ReadLine() ?? "";
                        }
                        else {
                            Console.WriteLine("No stack of flashcards to add a card exists.");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        cardOperator.CreateNewCard();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Shows table to delete card\n");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Shows table to select Stack for study session\n");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Shows table for Stack to see history\n");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please enter a valid input\n");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public void MainMenu () {
        Console.Clear();
        Console.WriteLine(
            """
            Main Menu 

            Select an option below
            --------------------------
            1. Add new Stack
            2. Delete a Stack
            3. Add new flashcard
            4. Delete a falshcard
            5. Begin Study Session
            6. View past Sessions

            0. Exit
            --------------------------
            """);
    }
}