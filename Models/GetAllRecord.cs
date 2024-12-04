namespace CrudOperationWithMongoDb.Models
{
    public class GetAllRecordResponse
    {
        public bool IsSuccess{ get;set;}
        public string Message { get; set; }
        public List<User> data { get; set; }
    }
}
