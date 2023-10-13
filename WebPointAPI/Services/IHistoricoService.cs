using WebPointAPI.Models;

namespace WebPointAPI.Services
{
    public interface IHistoricoService
    {
        Task<IEnumerable<Historico>> GetHistorico();

        Task<Historico> GetHistoricoById(int id);

        Task<IEnumerable<Historico>> GetHistoricoByNome(string nome);

        Task CreateHistorico(Historico historico);

        Task UpdateHistorico(Historico historico);

        Task DeleteHistorico(Historico historico);

        Task<IEnumerable<Historico>> GetHistoricoByEmail(string email);

    }
}
