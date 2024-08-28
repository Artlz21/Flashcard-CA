// using System.Linq;

// namespace FlashcardApp;

// public class StackOperator () {
//     private string getNameOfStack = "";

//     public void AddStack (List<Stacks> list) {
//         try {
//             int sortedSetSize = list.Count;
//             Console.WriteLine ("\nEnter a name for your stack or 0 to return to Main Menu: ");
//             getNameOfStack = Console.ReadLine () ?? "";
            
//             if (list.Any(stack => stack.Name == getNameOfStack) || getNameOfStack == "") {
//                 Console.WriteLine ("Name already exists or invalid name...");
//             }
//             else if (getNameOfStack == "0") {
//                 Console.WriteLine ("Returning to Main Menu... ");
//             }
//             else {
//                 Stacks stack= new Stacks{Id = sortedSetSize + 1, Name = getNameOfStack, Cards = []};
//                 list.Add(stack);
//                 Console.WriteLine($"New stack named {getNameOfStack} added. ");
//             }
//         }
//         catch (Exception ex) {
//             Console.WriteLine ("Error: " + ex.Message);
//         }
//         finally {
//             Console.WriteLine("Press enter to continue ");
//             Console.ReadLine();
//         }
//     }

//     public void DeleteStackFromList (List<Stacks> list) {
//         try {
//             Console.WriteLine("\nSelect a stack to delete by Name: ");
//             string nameToDelete = Console.ReadLine() ?? "";

//             Stacks? stackToDelete = list.FirstOrDefault(stack => stack.Name == nameToDelete);

//             if (stackToDelete != null) {
//                 Console.WriteLine(list.Remove(stackToDelete) ? $"Stack {nameToDelete} removed" : $"Stack {nameToDelete} was not removed");
//             }
//             else {
//                 Console.WriteLine("Stack not found...");
//             }
//         }
//         catch (Exception ex) {
//             Console.WriteLine("Error: Could not find stack" + ex.Message);
//         }
//         finally {
//             Console.WriteLine("Press enter to continue ");
//             Console.ReadLine();
//         }
//     }

//     public void CardsInStack (Stacks stack) {
//         if (stack.Cards != null) {
//             foreach(var card in stack.Cards) {
//                 Console.WriteLine($"{card.Id}" + card.FrontText);
//             }
//         }
//     }
// }