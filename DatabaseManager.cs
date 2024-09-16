using System;
using QC = Microsoft.Data.SqlClient;

namespace FlashcardApp {
    public class DatabaseManager {
        public DatabaseManager() {
            using (var connection = new QC.SqlConnection(  
				"Server=tcp:FlashcardDB.database.windows.net,1433;" +
				"Database=AdventureWorksLT;User ID=YOUR_LOGIN_NAME_HERE;" +
				"Password=YOUR_PASSWORD_HERE;Encrypt=True;" +
				"TrustServerCertificate=False;Connection Timeout=30;"  
				));
        }
    }
}