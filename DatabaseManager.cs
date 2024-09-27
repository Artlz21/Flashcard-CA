using System.Data.SqlClient;
using System.Globalization;

namespace FlashcardApp;

public class DatabaseManager {
    private readonly string ConnectionString;

    public DatabaseManager(string connection) {
        ConnectionString = connection;
    }

    public List<FlashcardStack> FlashcardStackGetAll() {
        List<FlashcardStack> FlashcardStackList = new();
        
        using var connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM FlashcardStacks";
            connection.Open();

            using var cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        FlashcardStack flashcardStack = new();
                        flashcardStack.ID = (int)reader["ID"];
                        flashcardStack.Name = (string)reader["StackName"];     
                        FlashcardStackList.Add(flashcardStack);                  
                    }
        
        return FlashcardStackList;
    }

    public FlashcardStack? FlashcardStackGet(FlashcardStack stack) {
        FlashcardStack flashcardStack = new();

        using var connection = new SqlConnection(ConnectionString);
            string query = 
            """
            SELECT * FROM FlashcardStacks
            WHERE StackName = @StackName
            """;
            connection.Open();

            using var cmd = new SqlCommand(query, connection);                
                cmd.Parameters.Add(new SqlParameter("@StackName", stack.Name));

                using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        flashcardStack.ID = (int)reader["ID"];
                        flashcardStack.Name = (string)reader["StackName"];
                    }
        
        return flashcardStack;
    }

    public void FlashcardStackPost(FlashcardStack flashcardStack) {
        using var connection = new SqlConnection(ConnectionString);
            string query = 
            """
            INSERT INTO FlashcardStacks (StackName)
            Values (@StackName)
            """;
            connection.Open();

            using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@StackName", flashcardStack.Name));
                cmd.ExecuteNonQuery();
                Console.WriteLine("New stack added.");
    }

    public void FlashcardStackDelete(FlashcardStack flashcardStack) {
        using var connection = new SqlConnection(ConnectionString);
            string query = 
            """
            DELETE FROM FlashcardStacks 
            WHERE StackName = @StackName
            """;
            connection.Open();

            using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@StackName", flashcardStack.Name));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Stack deleted.");
    }

    public List<Record> RecordsGetAll() {
        List<Record> RecordList = new();
        
        using var connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Records";
            connection.Open();

            using var cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Record record = new();
                        record.ID = (int)reader["ID"];
                        record.StackID = (int)reader["StackID"];     
                        record.Total = (int)reader["Total"];      
                        record.Correct = (int)reader["Correct"];
                        record.DateAndTime = (DateTime)reader["DateAndTime"];
                        RecordList.Add(record);      
                    }
        
        return RecordList;
    }

    public Record? RecordGet(Record record) {
        Record _record = new();

        using var connection = new SqlConnection(ConnectionString);
            string query = 
            """
            SELECT * FROM Records
            WHERE ID = @recordID
            """;
            connection.Open();

            using var cmd = new SqlCommand(query, connection);                
                cmd.Parameters.Add(new SqlParameter("@recordID", record.ID));

                using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        _record.ID = (int)reader["ID"];
                        _record.StackID = (int)reader["StackID"];     
                        _record.Total = (int)reader["Total"];      
                        _record.Correct = (int)reader["Correct"];
                        _record.DateAndTime = (DateTime)reader["DateAndTime"];
                    }
        
        return _record;
    }

    public void RecordPost(Record record) {
        using var connection = new SqlConnection(ConnectionString);
            string query = 
            """
            INSERT INTO Records (StackID, Correct, Total, DateAndTime)
            VALUES (@StackID, @Correct, @Total, @DateAndTime)
            """;
            connection.Open();

            using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@StackID", record.StackID));
                cmd.Parameters.Add(new SqlParameter("@Correct", record.Correct));
                cmd.Parameters.Add(new SqlParameter("@Total", record.Total));
                cmd.Parameters.Add(new SqlParameter("@DateAndTime", record.DateAndTime));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record added.");
    }

    public void RecordDelete(Record record) {
        using var connection = new SqlConnection(ConnectionString);
            string query = 
            """
            DELETE FROM Records 
            WHERE ID = @ID
            """;
            connection.Open();

            using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@ID", record.ID));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record Deleted.");
    }

    public List<Flashcard> FlashcardGetAll() {
        List<Flashcard> FlashcardList = new();
        
        using var connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Flashcard";
            connection.Open();

            using var cmd = new SqlCommand(query, connection);
                using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Flashcard flashcard = new();
                        flashcard.ID = (int)reader["ID"];
                        flashcard.StackID = (int)reader["StackID"];     
                        flashcard.FrontText = (string)reader["FrontText"];      
                        flashcard.BackText = (string)reader["BackText"];
                        flashcard.Marker = (bool)reader["Marker"];
                        FlashcardList.Add(flashcard);      
                    }
        
        return FlashcardList;
    }

    public Flashcard? FlashcardGet(Flashcard flashcard) {
        Flashcard _flashcard = new();

        using var connection = new SqlConnection(ConnectionString);
            string query = 
            """
            SELECT * FROM Flashcards
            WHERE ID = @ID
            """;
            connection.Open();

            using var cmd = new SqlCommand(query, connection);                
                cmd.Parameters.Add(new SqlParameter("@ID", flashcard.ID));

                using SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        _flashcard.ID = (int)reader["ID"];
                        _flashcard.StackID = (int)reader["StackID"];
                        _flashcard.FrontText = (string)reader["FrontText"];
                        _flashcard.BackText = (string)reader["BackText"];
                        _flashcard.Marker = (bool)reader["Marker"];
                    }
        
        return _flashcard;
    }

    public void FlashcardPost(Flashcard flashcard) {
        using var connection = new SqlConnection(ConnectionString);
            string query = 
            """
            INSERT INTO Flashcards (StackID, FrontText, BackText, Marker)
            VALUES (@StackID, @FrontText, @BackText, @Marker)
            """;
            connection.Open();

            using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@StackID", flashcard.StackID));
                cmd.Parameters.Add(new SqlParameter("@FrontText", flashcard.FrontText));
                cmd.Parameters.Add(new SqlParameter("@BackText", flashcard.BackText));
                cmd.Parameters.Add(new SqlParameter("@Marker", flashcard.Marker));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Flashcard added.");
    }

    public void FlashcardDelete(Flashcard flashcard) {
        using var connection = new SqlConnection(ConnectionString);
            string query = 
            """
            DELETE FROM Flashcards 
            WHERE ID = @ID
            """;
            connection.Open();

            using var cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@ID", flashcard.ID));
                cmd.ExecuteNonQuery();
                Console.WriteLine("Flashcard Deleted.");
    }
}
