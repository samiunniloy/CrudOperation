using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CrudOperationWithMongoDb.Models
{
    //public class InsertRecordRequest
    //{
    //    [BsonId]
    //    [BsonRepresentation(BsonType.ObjectId)]
    //    public string? Id { get; set; }
    //    public string CreateDate { get; set; }
    //    public string UpdateDate { get; set; }
    //    [Required]
    //    [BsonElement("Name")]
    //    public string Firstname { get; set; }
    //    [Required]
    //    public string Lasttname { get; set; }
    //    [Required]
    //    public int Age { get; set; }
    //    [Required]
    //    public string Contact { get; set; }

    //    public double Salary { get; set; }

    //}
    public class InsertRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
