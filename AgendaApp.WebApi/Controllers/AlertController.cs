using AgendaApp.Domain.DTO;
using AgendaApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgendaApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase
    {
        private readonly ILogger<AlertController> _logger;
        private readonly IAlertService _alertService;
        private readonly IAlertTypeService _alertTypeService;

        public AlertController(IAlertService alertService, IAlertTypeService alertTypeService, ILogger<AlertController> logger)
        {
            _logger = logger;
            _alertService = alertService;
            _alertTypeService = alertTypeService;
        }

        // GET: api/<AlertController>
        [HttpGet]
        [Route("types")]
        public IActionResult GetAlertTypes()
        {
            _logger.LogInformation($"The AlertController was invoked. Method: GetAlertTypes()");

            ResponseBase response = new ResponseBase();

            try
            {
                response.Data = _alertTypeService.GetAlertTypes();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.Data = null;
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return Problem(ex.Message, statusCode: HttpStatusCode.InternalServerError.GetHashCode());
            }

            _logger.LogInformation($"The AlertController was invoked. Method was finished: GetAlertTypes()");

            return Ok(response);
        }

        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation($"The AlertController was invoked. Method: GetById({id})");

            ResponseBase response = new ResponseBase();

            try
            {
                var result = _alertService.GetById(id);

                if (result == null) return NotFound();

                response.Data = result;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.Data = null;
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return Problem(ex.Message, statusCode: HttpStatusCode.InternalServerError.GetHashCode());
            }

            _logger.LogInformation($"The AlertController was invoked. Method was finished: GetById({id})");

            return Ok(response);
        }

        [HttpGet]        
        public IActionResult Get()
        {
            _logger.LogInformation($"The AlertController was invoked. Method: Get()");

            ResponseBase response = new ResponseBase();

            try
            {
                response.Data = _alertService.Get();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.Data = null;
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return Problem(ex.Message, statusCode: HttpStatusCode.InternalServerError.GetHashCode());
            }

            _logger.LogInformation($"The AlertController was invoked. Method was finished: Get()");

            return Ok(response);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] AlertDto dto)
        {
            _logger.LogInformation($"The AlertController was invoked. Method: Post()");

            ResponseBase response = new ResponseBase();

            try
            {
                response.Data = _alertService.Save(dto);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.Data = null;
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return Problem(ex.Message, statusCode: HttpStatusCode.BadRequest.GetHashCode());
            }

            _logger.LogInformation($"The AlertController was invoked. Method was finished: Post()");

            return Created("",response);
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] AlertDto dto)
        {
            _logger.LogInformation($"The AlertController was invoked. Method: Put()");

            ResponseBase response = new ResponseBase();

            try
            {
                response.Data = _alertService.Update(dto);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.Data = null;
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return Problem(ex.Message, statusCode: HttpStatusCode.BadRequest.GetHashCode());
            }

            _logger.LogInformation($"The AlertController was invoked. Method was finished: Put()");

            return Ok(response);
        }

        // DELETE api/<AlertController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"The AlertController was invoked. Method: Delete({id})");

            ResponseBase response = new ResponseBase();

            try
            {
                var entity = _alertService.GetById(id);
                if (entity == null) return NotFound();
                else _alertService.Delete(id);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                response.Data = null;
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return Problem(ex.Message, statusCode: HttpStatusCode.InternalServerError.GetHashCode());
            }

            _logger.LogInformation($"The AlertController was invoked. Method was finished: Delete({id})");

            return Ok(response);
        }
    }
}
