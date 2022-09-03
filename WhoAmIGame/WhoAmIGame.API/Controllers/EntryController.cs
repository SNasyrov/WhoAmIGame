using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhoAmIGame.Data;
using WhoAmIGame.Data.Models;

namespace WhoAmIGame.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private readonly DataContext _db;

        public EntryController(DataContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuest()
        {
            var random = new Random();
            var code = random.Next();

            var dbItem = new Person()
            {
                UserName = $"Гость {code}"
            };

            await _db.Person.AddAsync(dbItem);
            await _db.SaveChangesAsync();

            return Ok(dbItem);

        }
    }
}
