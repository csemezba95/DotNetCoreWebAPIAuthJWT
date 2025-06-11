using DotNetCoreWebAPIAuthJWT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPIAuthJWT.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Employees.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            return emp == null ? NotFound() : Ok(emp);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return Ok(emp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee emp)
        {
            var existing = await _context.Employees.FindAsync(id);
            if (existing == null) return NotFound();

            existing.EmployeeName = emp.EmployeeName;
            existing.CardNo = emp.CardNo;
            existing.Department = emp.Department;

            await _context.SaveChangesAsync();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return NotFound();

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var result = await _context.Employees
                .Where(e => e.EmployeeName.Contains(keyword) ||
                            e.CardNo.Contains(keyword) ||
                            e.Department.Contains(keyword))
                .ToListAsync();

            return Ok(result);
        }
    }

}
