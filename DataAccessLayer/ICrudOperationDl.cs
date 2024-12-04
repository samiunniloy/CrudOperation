using CrudOperationWithMongoDb.Models;
using System.Threading.Tasks;

namespace CrudOperationWithMongoDb.DataAccessLayer
{
    public interface ICrudOperationDl
    {
        public Task<InsertRecordResponse> InsertRecord(User request);
        public Task<GetAllRecordResponse> GetAllRecord();
        public Task<GetRecordByIdresponse> GetRecordById(string id);
        public Task<GetRecordByNameResponse> GetRecordByName(string id);
    }
}
