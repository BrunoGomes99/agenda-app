using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgendaApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase
    {
        private readonly ILogger<AlertController> _logger;

        public AlertController(ILogger<AlertController> logger)
        {
            _logger = logger;
        }

        // GET: api/<AlertController>
        [HttpGet]
        public IActionResult GetAlertTypes()
        {
            _logger.LogInformation($"The AlertController was invoked. Method: GetAlertTypes()");

            ResponseBase response = new ResponseBase();

            try
            {
                //response.Data = 
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

            _logger.LogInformation($"The AlertController was invoked. Method: GetAlertTypes()");

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
