using Microsoft.EntityFrameworkCore;
using WebPointAPI.Context;
using WebPointAPI.Models;

namespace WebPointAPI.Services
{
    public class HistoricoService : IHistoricoService
    {

        private readonly AppDbContext _context;

        public HistoricoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateHistorico(Historico historico)
        {
            _context.Historicos.Add(historico);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHistorico(Historico historico)
        {
            _context.Remove(historico);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Historico>> GetHistorico()
        {
            try
            {
                return await _context.Historicos.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Historico> GetHistoricoById(int id)
        {
            try
            {
                var historico = await _context.Historicos.FindAsync(id);
                return historico;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Historico>> GetHistoricoByNome(string nome)
        {
            IEnumerable<Historico> historicos;
            if (!string.IsNullOrEmpty(nome))
            {
                historicos = await _context.Historicos.Where(n => n.Nome.Contains(nome)).ToListAsync();
            }
            else
            {
                historicos = await GetHistorico();
            }
            return historicos;
        }

        public async Task UpdateHistorico(Historico historico)
        {
            _context.Entry(historico).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
