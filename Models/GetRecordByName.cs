namespace CrudOperationWithMongoDb.Models
{
    public class GetRecordByNameResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<User> data { get; set; }
    }
}
