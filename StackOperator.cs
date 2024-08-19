namespace FlashcardApp;

public class StackOperator () {
    private string getNameOfStack = "";
    public void AddStack () {
        try
        {
            Console.WriteLine ("Enter a name for your stack: ");
            getNameOfStack = Console.ReadLine () ?? "";
        }
        catch (Exception ex)
        {
            Console.WriteLine ("Error: " + ex.Message);
        }
    }

    public void ShowListOfStacks (List<Stack> list) {
        try {
            Console.WriteLine 
                ($"""
                List of recorded Stacks
                --------------------------
                """);
            foreach(var stack in list){
                Console.WriteLine(stack.Name);
            }
        }
        catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message); 
        }
    }
}