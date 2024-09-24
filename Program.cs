namespace FlashcardApp;

class Program
{
    static void Main(string[] args)
    {
        DatabaseManager databaseManager = new("Server=(localdb)\\FlashcardDB;Database=FlashcardDB;Trusted_Connection=True;");
        List<FlashcardStack>? list = databaseManager.FlashcardStackGetAll();

        // Menu menu = new("Server=(localdb)\\FlashcardDB;Database=FlashcardDB;Trusted_Connection=True;");

        // menu.StartApp();
    }
}
