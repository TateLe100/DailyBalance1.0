using DailyBalance1._0.Data;
using DailyBalance1._0.DTOs;
using DailyBalance1._0.Models;
using DailyBalance1._0.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DailyBalance1._0.Controllers
{
    [Route("api/BankAccount")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;
        //private readonly ApplicationDbContext _context;

        public BankAccountController(IBankAccountService bankAccountService) // , ApplicationDbContext context
        {
            _bankAccountService = bankAccountService;
            //_context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<BankAccountDTO>> GetAll()
        {
            var accounts = await _bankAccountService.GetAllBankAccountsAsync();
            return accounts; // Assuming a ToString() method or proper conversion
        }

        // GET api/<BankAccountController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccountDTO>> GetBankAccById(int id)
        {
            var account = await _bankAccountService.GetBankAccByIdAsync(id);
            return account;
        }

        // POST api/<BankAccountController>
        [HttpPost]
        public async Task<ActionResult<BankAccountDTO>> Post(BankAccountDTO bankAcc)
        {
            await _bankAccountService.CreateBankAccAsync(bankAcc);
            return CreatedAtAction("GetBankAccById", new { id = bankAcc.BankAccountId }, bankAcc);
        }

        // PUT api/<BankAccountController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BankAccountDTO>> Put(int id, BankAccountDTO bankAcc)
        {
            if(id != bankAcc.BankAccountId)
            {
                return BadRequest();
            }

            await _bankAccountService.EditBankAcc(id, bankAcc);
            return NoContent();
        }

        // DELETE api/<BankAccountController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccAsync(int id)
        {
            if (await _bankAccountService.DeleteBankAccAsync(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
