using WebPointAPI.Models;

namespace WebPointAPI.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int Id);

        Task<IEnumerable<Usuario>> GetUsuariosByNome(string nome);

        Task CreatUsuario(Usuario usuario);   

        Task UpdateUsuario(Usuario usuario);

        Task DeleteUsuario (Usuario usuario);
    }
}
