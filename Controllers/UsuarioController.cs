using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


using ProfesionalesAPI.Data;
using ProfesionalesAPI.Dto;
using ProfesionalesAPI.Models;

namespace ProfesionalesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly JwtSettings _jwtSettings;

        public UsuarioController(DataContext context, IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuario()
        {
            return Ok(_context.Usuarios.ToList());
        }

        [HttpGet("{id:int}")]

        public ActionResult<Usuario> GetUsuarioById(int id)
        {
            var Usuario = _context.Usuarios.FirstOrDefault(p => p.Id == id);
            return Usuario is not null ? Ok(Usuario) : NotFound();
        }

        [HttpPost]

        public ActionResult<Usuario> CreateUsuario(Usuario nuevoUsuario)
        {
            var rol = _context.Roles.Find(nuevoUsuario.Rol);
            if (rol == null)
            {
                return NotFound("El Rol especificado no existe.");
            }

            //encryptar password
            nuevoUsuario.Password = BCrypt.Net.BCrypt.HashPassword(nuevoUsuario.Password);

            _context.Usuarios.Add(nuevoUsuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsuarioById), new { id = nuevoUsuario.Id }, nuevoUsuario);

        }
        [HttpPost("login")]

        public IActionResult Login([FromBody] LoginDto usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.Identificacion == usuario.Identificaicon);

            if (user is null)
            {
                return Unauthorized("Credenciales inválidas");
            }
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(usuario.Password, user.Password);
            if (!isPasswordValid)
            {
                return Unauthorized("Credenciales inválidas");
            }
            var token = GenerateJwtToken(user);

            return Ok(new { token });
        }

        private string GenerateJwtToken(Usuario user)
        {
            var issuerSigningKey = _jwtSettings.SecretKey;
            if (string.IsNullOrEmpty(issuerSigningKey))
            {
                throw new InvalidOperationException("Issuer signing key is not configured.");
            }

            var keyBytes = Encoding.UTF8.GetBytes(issuerSigningKey);
            if (keyBytes.Length < 32)
            {
                throw new InvalidOperationException("Secret key must be at least 32 bytes (256 bits) for HS256.");
            }

            var securityKey = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Correo ?? string.Empty),
        new Claim("role", "Usuario")
    };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPut("{id:int}")]

        public IActionResult UpdateUsuario(int id, Usuario UsuarioActualizado)
        {
            var Usuario = _context.Usuarios.FirstOrDefault(p => p.Id == id);
            if (Usuario is null) return NotFound();
            _context.Update(UsuarioActualizado);
            return NoContent();
        }

        [HttpDelete("{id:int}")]

        public IActionResult DeleteUsuario(int id)
        {
            var Usuario = _context.Usuarios.FirstOrDefault(p => p.Id == id);
            if (Usuario is null) return NotFound();
            _context.Usuarios.Remove(Usuario);
            return NoContent();
        }

        [HttpPost("codigo")]
        [AllowAnonymous]
        public IActionResult GenerarCodigo()
        {
            Random random = new Random();
            int codigo = random.Next(100000, 999999);

            return Ok(new { Codigo = codigo });
        }

    }
}