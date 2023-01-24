using AgendaApp.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgendaApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase
    {
        private readonly ILogger<AlertController> _logger;
        private readonly IAlertTypeService _alertTypeService;

        public AlertController(IAlertTypeService alertTypeService, ILogger<AlertController> logger)
        {
            _logger = logger;
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

                throw new Exception(ex.Message);                
            }

            _logger.LogInformation($"The AlertController was invoked. Method was finished: GetAlertTypes()");

            return Ok(response);
        }

        // GET api/<AlertController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlertController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AlertController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlertController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
