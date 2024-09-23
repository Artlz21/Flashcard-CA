using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Microsoft.IdentityModel.Tokens;

namespace FlashcardApp;
public class FlashcardServices(string ConnectionString)
{
    private FlashcardStackMapper flashcardStackMapper = new();
    private RecordMapper recordMapper = new();
    private FlashCardMapper flashcardMapper = new();
    private DatabaseManager databaseManager = new(ConnectionString);

    public List<FlashcardStackDTO>? GetAllStackDTOs() {
        List<FlashcardStack>? stacks = databaseManager.FlashcardStackGetAll();
        List<Record>? records = databaseManager.RecordsGetAll();
        List<Flashcard>? flashcards = databaseManager.FlashcardGetAll();
        List<FlashcardStackDTO> stacksDTO = new();
        
        if (stacks == null || stacks.Count == 0)
            return null;

        foreach (var stack in stacks) { 
            List<Record>? recordsBelongingToStack = records?.FindAll(record => record.StackID == stack.ID);
            List<Flashcard>? flashcardsBelongingToStack = flashcards?.FindAll(
                flashcard => flashcard.StackID == stack.ID
            );

            List<RecordDTO> recordDTOs = recordMapper.RecordDTOMapper(recordsBelongingToStack ?? new List<Record>());
            List<FlashCardDTO> flashCardDTOs = flashcardMapper.FlashCardDTOMapper(flashcardsBelongingToStack ?? new List<Flashcard>());

            FlashcardStackDTO flashcardStackDTO = new() { 
                Name = stack.Name, 
                Flashcards = flashCardDTOs, 
                Records = recordDTOs 
            };
            stacksDTO.Add(flashcardStackDTO);
        }

        return stacksDTO;
    }
}
