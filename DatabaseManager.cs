using System.Data.SqlClient;
using System.Globalization;

namespace FlashcardApp {
    public class DatabaseManager {
        private readonly string ConnectionString;

        public DatabaseManager(string connection) {
            ConnectionString = connection;
        }

        public void ConnectToDatabase() {
            using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                Console.WriteLine("DB Connected successfully");
        }

        public List<FlashcardStack>? FlashcardStackGetAll() {
            List<FlashcardStack> FlashcardStackList = new();
            
            using var connection = new SqlConnection(ConnectionString);
                string query = "SELECT * FROM FlashcardStacks";
                connection.Open();

                using var cmd = new SqlCommand(query, connection);
                    using SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            FlashcardStack flashcardStack = new();
                            flashcardStack.Id = (int)reader["ID"];
                            flashcardStack.Name = (string)reader["StackName"];     
                            FlashcardStackList.Add(flashcardStack);                  
                        }
            
            return FlashcardStackList;
        }

        public FlashcardStack? FlashcardStackGet(string stack) {
            FlashcardStack flashcardStack = new();

            using var connection = new SqlConnection(ConnectionString);
                string query = 
                """
                SELECT * FROM FlashcardStacks
                WHERE StackName = @StackName
                """;
                connection.Open();

                using var cmd = new SqlCommand(query, connection);                
                    cmd.Parameters.Add(new SqlParameter("@StackName", stack));

                    using SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read()) {
                            flashcardStack.Id = (int)reader["ID"];
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

        public void FlashcardStackUpdate(FlashcardStack flashcardStack) {
            using var connection = new SqlConnection(ConnectionString);
                string query = 
                """
                UPDATE FlashcardStacks 
                SET StackName = @StackName
                WHERE ID = @ID
                """;
                connection.Open();

                using var cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@StackName", flashcardStack.Name));
                    cmd.Parameters.Add(new SqlParameter("@ID", flashcardStack.Id));
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Stack updated");
        }
    }
}