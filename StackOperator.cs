using System.Linq;

namespace FlashcardApp;

public class StackOperator () {
    private string getNameOfStack = "";
    public void AddStack (SortedSet<Stacks> list) {
        try {
            ShowListOfStacks(list);
            Console.WriteLine ("Enter a name for your stack: ");
            getNameOfStack = Console.ReadLine () ?? "";
            
            if (list.Any(stack => stack.Name == getNameOfStack) || getNameOfStack == "") {
                Console.WriteLine ("Name already exists or invalid name...");
            }
            else {    
                Stacks stack= new Stacks{Name = getNameOfStack};
                list.Add(stack);
                Console.WriteLine($"New stack named {getNameOfStack} added. ");
            }
        }
        catch (Exception ex) {
            Console.WriteLine ("Error: " + ex.Message);
        }
        finally {
            Console.WriteLine("Press enter to continue ");
            Console.ReadLine();
        }
    }

    public void ShowListOfStacks (SortedSet<Stacks> list) {
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
        }
        catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message); 
        }
    }

    public void DeleteStackFromList (SortedSet<Stacks> list) {
        try {
            ShowListOfStacks(list);
            Console.WriteLine("\nSelect a stack to delete by Name: ");
            string nameToDelete = Console.ReadLine() ?? "";

            Stacks? stackToDelete = list.FirstOrDefault(stack => stack.Name == nameToDelete);

            if (stackToDelete != null) {
                Console.WriteLine(list.Remove(stackToDelete) ? $"Stack {nameToDelete} removed" : $"Stack {nameToDelete} was not removed");
            }
            else {
                Console.WriteLine("Stack not found...");
            }
        }
        catch (Exception ex) {
            Console.WriteLine("Error: Could not find stack" + ex.Message);
        }
        finally {
            Console.WriteLine("Press enter to continue ");
            Console.ReadLine();
        }
    }
}