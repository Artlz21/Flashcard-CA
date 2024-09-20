namespace FlashcardApp;

class Program
{
    static void Main(string[] args)
    {
        DatabaseManager databaseManager = new("Server=(localdb)\\FlashcardDB;Database=FlashcardDB;Trusted_Connection=True;");
        List<FlashcardStack>? list = databaseManager.FlashcardStackGetAll();
        foreach(var l in list) {
            Console.WriteLine(l.Name);
        }

        // Menu menu= new Menu();

        // menu.StartApp();
    }
}
