using System.Linq;

namespace FlashcardApp;

/*
Need to work on changing each use of stack objects to align more with the new DTO design that shoud be 
used for business logic.
*/
public class StackManager () {
    // Creates new stacks to hold flashcards and add to list of existing stacks
    public void AddNewStack (List<FlashcardStackDTO> ListOfStacks) {
        Console.WriteLine("\nEnter a new Stack name: ");
        string newStackName = Console.ReadLine() ?? ""; 

        bool checkIfNameIsRepeated = ListOfStacks.Any(stack => stack.Name == newStackName);

        // Checks if user input is valid
        if (string.IsNullOrEmpty(newStackName) || checkIfNameIsRepeated) {
            Console.WriteLine("Enter a valid and unique name");
        }
        else {
            FlashcardStackDTO NewStack = new() { Name = newStackName };
            ListOfStacks.Add(NewStack);
            Console.WriteLine($"Stack named {newStackName} added.");
        }
    }

    public FlashcardStackDTO? GetSelectedStack(List<FlashcardStackDTO> ListOfStacks) {
        string stackToSelect = Console.ReadLine() ?? ""; 
        FlashcardStackDTO? stack = ListOfStacks.FirstOrDefault(stack => stack.Name == stackToSelect);

        if (stack == null) {
            return null;
        }
        
        return stack;
    }

    public void DeleteStack(List<FlashcardStackDTO> ListOfStacks, FlashcardStackDTO stack) {
        ListOfStacks.Remove(stack);
        Console.WriteLine($"Stack named {stack.Name} and all Cards removed");
    }

    public void ShowRecord(FlashcardStackDTO stack) {
        Console.Clear();
        int count = 1;

        if (stack.Records == null) {
            Console.WriteLine("No Records for Stack saved...");
        }
        else {
            Console.WriteLine($"Record for {stack.Name}");
            foreach (var record in stack.Records) {
                Console.WriteLine($"{count}.) Date: {record.DateAndTime}, Score: {record.Correct} / {record.Total}");
                count+=1;
            }
        }
    }
}