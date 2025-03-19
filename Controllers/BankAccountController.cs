using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DailyBalance1._0.Controllers
{
    [Route("api/BankAccount")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        //private readonly IBankAccountService _bankAccountService;
        private readonly DailyBalance1.Context _context;


        // GET: api/<BankAccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BankAccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BankAccountController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<BankAccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<BankAccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
