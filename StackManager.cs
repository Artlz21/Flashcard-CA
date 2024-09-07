using System.Linq;

namespace FlashcardApp;

public class StackManager () {
    // Creates new stacks to hold flashcards and add to list of existing stacks
    public void AddNewStack (List<FlashcardStack> ListOfStacks) {
        Console.WriteLine("\nEnter a new Stack name: ");
        string newStackName = Console.ReadLine() ?? ""; 

        // Checks if user input is valid
        if (newStackName == "" || newStackName == null) 
            Console.WriteLine("Enter a valid name");
        else {
            FlashcardStack NewStack = new() { Id = ListOfStacks.Count + 1, Name = newStackName, Records = [] };
            ListOfStacks.Add(NewStack);
            Console.WriteLine($"Stack named {newStackName} added.");
        }
    }

    public FlashcardStack? GetSelectedStack(List<FlashcardStack> ListOfStacks) {
        string stackToSelect = Console.ReadLine() ?? ""; 
        FlashcardStack? stack = ListOfStacks.FirstOrDefault(stack => stack.Name == stackToSelect);

        if (stack == null) {
            return null;
        }
        
        return stack;
    }

    public void DeleteStack(List<FlashcardStack> ListOfStacks, List<FlashCard> ListOfFlashcards, FlashcardStack stack) {
        ListOfFlashcards.RemoveAll(card => card.StackID == stack.Id);
        ListOfStacks.Remove(stack);
        Console.WriteLine($"Stack named {stack.Name} and all Cards removed");
    }

    public void ShowRecord(FlashcardStack stack) {
        Console.Clear();
        int count = 1;

        Console.WriteLine($"Record for {stack.Name}");
        foreach (var record in stack.Records) {
            Console.WriteLine($"{count}. Date: {record.DateAndTime}, Score: {record.Correct} / {record.Total}");
            count+=1;
        }
    }
}