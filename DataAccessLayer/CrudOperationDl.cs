using CrudOperationWithMongoDb.DataAccessLayer;
using CrudOperationWithMongoDb.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CrudOperationWithMongoDb.DataAccessLayer
{
    public class CrudOperationDl:ICrudOperationDl
    {
        private readonly IConfiguration _configuration;
        private readonly MongoClient _mongoClient;
        private readonly IMongoCollection<User>_mongoCollection;
        public CrudOperationDl(IConfiguration configuration)
        {
            _configuration = configuration;
            _mongoClient = new MongoClient(_configuration["DatabaseSetting:ConnectionString"]);
            var _MongoDatabase=_mongoClient.GetDatabase(_configuration["DatabaseSetting:DatabaseName"]);
            _mongoCollection = _MongoDatabase.GetCollection<User>(_configuration["DatabaseSetting:CollectionName"]);
        }

        public async Task<InsertRecordResponse> InsertRecord(User request)

        {
            InsertRecordResponse response = new InsertRecordResponse();
            response.IsSuccess = true;
            response.Message = "Succesfull";
            try
            {
                request.CreateDate = DateTime.Now.ToString();
                request.UpdateDate = String.Empty;
                await _mongoCollection.InsertOneAsync(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occur " + ex.Message;
            }
            return response;
        }

        public async Task<GetAllRecordResponse> GetAllRecord()
        {
            GetAllRecordResponse response = new GetAllRecordResponse();
            response.IsSuccess = true;
            response.Message = "get All record succesfull";
            try
            {
                response.data = new List<User>();
                response.data = await _mongoCollection.Find(x=>true).ToListAsync();
                if (response.data.Count==0)
                {
                    response.Message = "No data Found";

                }
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = "Failed :" + ex.Message;
              
            }
            return response;
        }

        public async Task<GetRecordByIdresponse> GetRecordById(string id)
        {
            GetRecordByIdresponse response = new GetRecordByIdresponse();
            response.IsSuccess = true;
            response.Message = "GetRecordBYID successfull";

            try
            {
                response.data = new User();
                response.data = await _mongoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
                if (response.data == null)
                {
                    response.Message="Invalid id";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Failed :" + ex.Message;
            }
            return response;
        }

        public async Task<GetRecordByNameResponse> GetRecordByName(string Name)
        {
            GetRecordByNameResponse response = new GetRecordByNameResponse();
            response.IsSuccess = true;
            response.Message = "GetRecordBYyNameessfull";

            try
            {
                response.data = new List<User>();
                response.data = await _mongoCollection.Find(x =>( x.Firstname == Name||x.Lasttname==Name)).ToListAsync();
                if (response.data.Count==0)
                {
                    response.Message = "Invalid Name";
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Failed :" + ex.Message;
            }
            return response;

        }
    }
}
