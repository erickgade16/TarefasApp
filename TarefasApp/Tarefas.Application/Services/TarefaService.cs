using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces;

namespace Tarefas.Application.Services
{
    public class TarefaService
    {
        private readonly ITarefaRepository _repository;

        public TarefaService(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Tarefa>> ObterTodasAsync() => _repository.ObterTodasAsync();
        public Task<Tarefa> ObterPorIdAsync(int id) => _repository.ObterPorIdAsync(id);
        public Task<Tarefa> AdicionarAsync(Tarefa tarefa) => _repository.AdicionarAsync(tarefa);

        public Task AtualizarAsync(Tarefa tarefa) => _repository.AtualizarAsync(tarefa);
        public Task DeletarAsync(int id) => _repository.DeletarAsync(id);


    }
}
