using Microsoft.AspNetCore.Mvc;

using ProfesionalesAPI.Data;
using ProfesionalesAPI.Models;

namespace ProfesionalesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolController : ControllerBase
    {
        private readonly DataContext _context;

        public RolController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Rol>> GetRol()
        {
            return Ok(_context.Roles.ToList());
        }

        [HttpGet("{id:int}")]
        public ActionResult<Rol> GetRolById(int id)
        {
            var Rol = _context.Roles.FirstOrDefault(p => p.Id == id);
            return Rol is not null ? Ok(Rol) : NotFound();
        }

        [HttpPost]
        public ActionResult<Rol> CreateRol(Rol nuevoRol)
        {
            _context.Roles.Add(nuevoRol);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetRolById), new { id = nuevoRol.Id }, nuevoRol);

        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateRol(int id, Rol RolActualizado)
        {
            var Rol = _context.Roles.FirstOrDefault(p => p.Id == id);
            if (Rol is null) return NotFound();
            _context.Update(RolActualizado);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteRol(int id)
        {
            var Rol = _context.Roles.FirstOrDefault(p => p.Id == id);
            if (Rol is null) return NotFound();
            _context.Roles.Remove(Rol);
            return NoContent();
        }
    }
}