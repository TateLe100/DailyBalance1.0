using DailyBalance1._0.DTOs;
using DailyBalance1._0.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DailyBalance1._0.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;
        public UserController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpGet]
        public async Task<IEnumerable<ApplicationUserDTO>> GetAllUsers()
        {
            var users = await _userAccountService.GetAllBankAccountsAsync();
            return users; 
        }

        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<ApplicationUserDTO>> Post(ApplicationUserDTO userAccount)
        {
            await _userAccountService.CreateUserAccAsync(userAccount);
            return CreatedAtAction("GetBankAccById", new { id = userAccount.Id }, userAccount);
        }

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
