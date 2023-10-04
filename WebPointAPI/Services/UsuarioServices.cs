using Microsoft.EntityFrameworkCore;
using WebPointAPI.Context;
using WebPointAPI.Models;

namespace WebPointAPI.Services
{
    public class UsuarioServices : IUsuarioService
    {
        private readonly AppDbContext _context;

        public UsuarioServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            try
            {
                return await _context.Usuarios.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosByNome(string nome)
        {

            IEnumerable<Usuario> usuarios;
            if (!string.IsNullOrEmpty(nome)) 
            { 
                usuarios = await _context.Usuarios.Where(n=> n.Nome.Contains(nome)).ToListAsync();   
            }
            else
            {
                usuarios = await GetUsuarios();
            }
            return usuarios;
        }

        public async Task<Usuario> GetUsuario(int Id)
        {
            var usuario = await _context.Usuarios.FindAsync(Id);
            return usuario;
        }

        public async Task CreatUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsuario(Usuario usuario)
        {
            _context.Remove(usuario);
            await _context.SaveChangesAsync();
        }

    }
}
