using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.database;
using WebAPIDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ToDoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ToDoController>
        [HttpGet("GetTodos")]
        public async Task<ActionResult<IEnumerable<ToDo>>> Get()
        {
            return await _context.Todos.Include(p => p.User).ToListAsync();
        }

        [HttpGet]
        // GET api/<ToDoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> GetTodo(int id)
        {
            var todo = await _context.Todos
                .Include(t => t.User)
                .ThenInclude(x => (x as User).Name)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        // POST api/<ToDoController>
        [HttpPost]
        public async Task<ActionResult<ToDo>> CreateTodo(ToDo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
        }

        // PUT api/<ToDoController>/5
        [HttpPut("UpdateTodo/{id}")]
        public async Task<ActionResult<ToDo>> UpdateTodo(int id, ToDo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }

            _context.Entry(todo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return todo;
        }

        // DELETE api/<ToDoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDo>> DeleteTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public bool TodoExists(int id)
        {
            return _context.Todos.Any(x => x.Id == id);
        }
    }
}