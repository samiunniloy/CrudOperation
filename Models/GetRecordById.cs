namespace CrudOperationWithMongoDb.Models
{
    public class GetRecordByIdresponse
    {
        public bool IsSuccess { get; set; }
        public string Message {  get; set; }
        public User data { get; set; }
    }
}
