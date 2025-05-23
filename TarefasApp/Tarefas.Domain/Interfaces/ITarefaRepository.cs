using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarefas.Domain.Entities;

namespace Tarefas.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> ObterTodasAsync();
        Task<Tarefa?> ObterPorIdAsync(int id);
        Task<Tarefa> AdicionarAsync(Tarefa tarefa);
        Task AtualizarAsync(Tarefa tarefa);
        Task DeletarAsync(int id);
    }
}
