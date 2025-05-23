using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarefas.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public bool Concluido { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}
