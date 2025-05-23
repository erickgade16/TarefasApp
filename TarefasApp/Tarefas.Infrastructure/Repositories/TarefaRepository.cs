using Microsoft.EntityFrameworkCore;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces;
using Tarefas.Infrastructure.Context;

namespace Tarefas.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TarefasDbContext _context;

        public TarefaRepository(TarefasDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tarefa>> ObterTodasAsync()
            => await _context.Tarefas.ToListAsync();

        public async Task<Tarefa?> ObterPorIdAsync(int id)
            => await _context.Tarefas.FindAsync(id);

        public async Task<Tarefa> AdicionarAsync(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task AtualizarAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
