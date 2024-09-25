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

    public void AddCardToStack(FlashcardStackDTO flashcardStackDTO, FlashcardDTO flashcardDTO) {
        flashcardStackDTO.Flashcards?.Add(flashcardDTO);
        FlashcardStack? flashcardStack = databaseManager.FlashcardStackGet(flashcardStackDTO);

        if (flashcardStack != null) {
            Flashcard flashcard = new() { 
                FrontText = flashcardDTO.FrontText, 
                BackText = flashcardDTO.BackText, 
                StackID = flashcardStack.ID
            };

            databaseManager.FlashcardPost(flashcard);
        }
        else {
            Console.WriteLine("No Stack found matching name...");
        }
    }

    public void DeleteCardFomStack(FlashcardStackDTO flashcardStackDTO, FlashcardDTO flashcardDTO) {
        flashcardStackDTO.Flashcards?.Remove(flashcardDTO);
        databaseManager.FlashcardDelete(flashcardDTO);
    }

    public void AddStack(List<FlashcardStackDTO> listOfStacks, FlashcardStackDTO flashcardStackDTO) {
        listOfStacks.Add(flashcardStackDTO);
        FlashcardStack flashcardStack = new() { Name = flashcardStackDTO.Name };
        databaseManager.FlashcardStackPost(flashcardStack);
    }

    public void DeleteStack(List<FlashcardStackDTO> listOfStacks, FlashcardStackDTO flashcardStackDTO) {
        listOfStacks.Remove(flashcardStackDTO);
        databaseManager.FlashcardStackDelete(flashcardStackDTO);
    }
}