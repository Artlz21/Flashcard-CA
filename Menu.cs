namespace FlashcardApp; 

public class Menu () {
    private bool exitApp = false; 
    private string mainMenuSelection = "";
    private int optionSelected = -1;

    // used to hold collections flashcard stacks that hold respective flashcards
    private List<Stacks> list = [];

    // used to handle viewing and any changes to flashcard stacks
    private StackOperator stackOperator = new();

    private CardOperator cardOperator = new();

    public void StartApp() {
        FlashCard FirstCard = new FlashCard{ Id = 1, ForeignKey = 1, FrontText = "First", BackText = "First"};
        FlashCard SecondCard = new FlashCard{ Id = 2, ForeignKey = 1, FrontText = "Second", BackText = "Second"};
        FlashCard ThirdCard = new FlashCard{ Id = 3, ForeignKey = 1, FrontText = "Third", BackText = "Third"};
        Stacks First = new() { Id = 1, Name = "First", Cards = [FirstCard, SecondCard, ThirdCard]};
        Stacks Second = new() { Id = 2, Name = "Second", Cards = []};
        list.Add(First);
        list.Add(Second);

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
                        ShowListOfStacks(list);
                        stackOperator.AddStack(list);
                        break;
                    case 2:
                        Console.Clear();
                        ShowListOfStacks(list);
                        stackOperator.DeleteStackFromList(list);
                        break;
                    case 3:
                        Console.Clear();
                        string stackName = "";

                        if (list.Count > 0) {
                            ShowListOfStacks(list);
                            Console.WriteLine("Enter a stack name to add a card too. ");
                            stackName = Console.ReadLine() ?? "";
                        }
                        else {
                            Console.WriteLine("No stack of flashcards to add a card exists.");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }

                        cardOperator.CreateNewCard(list, stackName);
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

    public void ShowListOfStacks (List<Stacks> list) {
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