using System.Data.SqlClient;

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

        public void FlashcardStackGetAll() {
            using var connection = new SqlConnection(ConnectionString);
                connection.Open();
                string query = "SELECT * FROM FlashcardStacks";

                using var cmd = new SqlCommand(query, connection);
                    using SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["ID"]}, Stack Name: {reader["StackName"]}");
                        }
        }

        public void FlashcardStackGet(string stack) {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
                using var cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = 
                    """
                    SELECT * FROM FlashcardStacks
                    WHERE StackName = @StackName
                    """;
                
                    cmd.Parameters.Add(new SqlParameter("@StackName", stack));

                    using SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read()) {
                            Console.WriteLine($"ID: {reader["ID"]}, Stack Name: {reader["StackName"]}");
                        }
        }

        public void FlashcardStackPost() {

        }

        public void FlashcardStackDelete() {

        }

        public void FlashcardStackUpdate() {

        }
    }
}