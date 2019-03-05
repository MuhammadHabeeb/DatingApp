using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.api.Controllers
{
    // http://localhost:5000/api/values
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            // throw new Exception();
            var values =await _context.Values.ToListAsync();
            return Ok(values); 
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValues(int id)
        {
            var _value = await _context.Values.FirstOrDefaultAsync(v => v.Id == id);
           if(_value == null)
           return NotFound();
           else
           return Ok(_value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}