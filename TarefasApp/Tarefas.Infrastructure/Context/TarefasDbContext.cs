using Microsoft.EntityFrameworkCore;
using Tarefas.Domain.Entities;
using Tarefas.Domain.Interfaces;
using Tarefas.Infrastructure.Context;

namespace Tarefas.Infrastructure.Context
{
    public class TarefasDbContext : DbContext
    {
        public TarefasDbContext(DbContextOptions<TarefasDbContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas => Set<Tarefa>();
    }
}
