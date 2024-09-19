namespace FlashcardApp;

class Program
{
    static void Main(string[] args)
    {
        DatabaseManager databaseManager = new("Server=(localdb)\\FlashcardDB;Database=FlashcardDB;Trusted_Connection=True;");
        databaseManager.FlashcardStackGet("Second");

        // Menu menu= new Menu();

        // menu.StartApp();
    }
}
