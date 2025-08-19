using EmployCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmployServiceCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employ2Controller : ControllerBase
    {
        private readonly EFCoreDbContext _context;

        public Employ2Controller(EFCoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Employ2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employ2>>> GetEmploy()
        {
            return await _context.Employ.ToListAsync();
        }

        // GET: api/Employ2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employ2>> GetEmploy2(int id)
        {
            var employ = await _context.Employ.FindAsync(id);

            if (employ == null)
            {
                return NotFound();
            }

            return employ;
        }

        //Console.WriteLine("Sending Mail");
        //Console.WriteLine(SendMail.MailInfo("prassucp@gmail.com", "Dotnet Code", "This is My First Mail in Dotnet"));
        //return await _context.Employees.ToListAsync();
        // PUT: api/Employ2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploy2(int id, Employ2 employ2)
        {
            if (id != employ2.Empno)
            {
                return BadRequest();
            }

            _context.Entry(employ2).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employ2Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employ2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employ2>> PostEmploy2(Employ2 employ2)
        {
            _context.Employ.Add(employ2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmploy2", new { id = employ2.Empno }, employ2);
        }

        // DELETE: api/Employ2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploy2(int id)
        {
            var employ2 = await _context.Employ.FindAsync(id);
            if (employ2 == null)
            {
                return NotFound();
            }

            _context.Employ.Remove(employ2);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Employ2Exists(int id)
        {
            return _context.Employ.Any(e => e.Empno == id);
        }
    }
}
