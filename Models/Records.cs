namespace FlashcardApp;

public class Record {
    public int ID { get; set; } 
    public int StackID { get; set; }
    public int Total { get; set; }
    public int Correct { get; set; }
    public DateTime DateAndTime { get; set; }
}

public class RecordDTO(Record record) {
    public int Total = record.Total;
    public int Correct = record.Correct;
    public DateTime DateAndTime = record.DateAndTime;
}

// public class RecordMapper {
//     public RecordDTO RecordDTOMapper(Record record) {
//         return new RecordDTO{
//             Total = record.Total,
//             Correct = record.Correct,
//             DateAndTime = record.DateAndTime
//         };
//     }

//     public List<RecordDTO> RecordDTOMapper(List<Record> records) {
//         List<RecordDTO> recordDTOList = new();
        
//         foreach (var record in records) {
//             RecordDTO recordDTO = new() { 
//                 Total = record.Total, Correct = record.Correct, DateAndTime = record.DateAndTime
//             };
//             recordDTOList.Add(recordDTO);
//         }
        
//         return recordDTOList;
//     }
// }