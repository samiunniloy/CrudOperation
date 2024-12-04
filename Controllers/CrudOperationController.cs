using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudOperationWithMongoDb.DataAccessLayer;
using CrudOperationWithMongoDb.Models;
using MongoDB.Bson;
namespace CrudOperationWithMongoDb.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        private readonly ICrudOperationDl _crudOperationDl;
        public CrudOperationController(ICrudOperationDl crudOperationDl)
        {
            _crudOperationDl=crudOperationDl;
        }
        [HttpPost]
        public async Task<IActionResult> InsertRecord(User request)
        {
            InsertRecordResponse response = new InsertRecordResponse();
            try
            {
                response = await _crudOperationDl.InsertRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occur " + ex.Message;
            }
            return Ok(response);

        }
        [HttpGet]
        public async Task<IActionResult> GetAllRecord()
        {
            GetAllRecordResponse response = new GetAllRecordResponse();
            try
            {
                response = await _crudOperationDl.GetAllRecord();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occur " + ex.Message;
            }
            return Ok(response);

        }

        [HttpGet]
        public async Task<IActionResult> GetRecordById([FromQuery]string id)
        {
            GetRecordByIdresponse response = new GetRecordByIdresponse();
            try
            {   //Guid Id=Guid.Parse(id);
                response = await _crudOperationDl.GetRecordById(id);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occur " + ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetRecordByName([FromQuery] string Name)
        {
            GetRecordByNameResponse response = new GetRecordByNameResponse();
            try
            {   //Guid Id=Guid.Parse(id);
                response = await _crudOperationDl.GetRecordByName(Name);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Exception Occur " + ex.Message;
            }
            return Ok(response);

        }
    }
}
