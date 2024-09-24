using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Microsoft.IdentityModel.Tokens;

namespace FlashcardApp;
public class FlashcardServices(string ConnectionString)
{
    private DatabaseManager databaseManager = new(ConnectionString);

    public List<FlashcardStackDTO>? GetAllStackDTOs() {
        List<FlashcardStack>? stacks = databaseManager.FlashcardStackGetAll();
        List<Record>? records = databaseManager.RecordsGetAll();
        List<Flashcard>? flashcards = databaseManager.FlashcardGetAll();
        List<FlashcardStackDTO> stackDTOs = new();
        
        if (stacks == null || stacks.Count == 0)
            return null;

        foreach (var stack in stacks) {
            List<Record>? recordsBelongingToStack = records?.FindAll(r => r.StackID == stack.ID);
            List<Flashcard>? flashcardsBelongingToStack = flashcards?.FindAll(f => f.StackID == stack.ID);

            List<RecordDTO>? recordDTOs = recordsBelongingToStack?.ConvertAll(r => new RecordDTO(r));
            List<FlashcardDTO>? flashcardDTOs = flashcardsBelongingToStack?.ConvertAll(f => new FlashcardDTO(f));

            FlashcardStackDTO flashcardStackDTO = new(stack, flashcardDTOs, recordDTOs);
            stackDTOs.Add(flashcardStackDTO);
        }
        return stackDTOs;
    }
}