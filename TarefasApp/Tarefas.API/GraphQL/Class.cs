using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
ussing 

namespace Tarefas.API.GraphQL
{
    public class Query
    {
        public async Task<List<Conta>> GetContas([Service] IContaRepository contaRepository)
        {
            var contas = await contaRepository.ObterTodasAsync(); // Crie este método no repository!
            return contas;
        }

        public async Task<Conta> GetContaPorNumero(string numeroConta, [Service] IContaRepository contaRepository)
        {
            var conta = await contaRepository.ObterPorNumeroAsync(numeroConta);
            if (conta == null)
                throw new ArgumentException("Conta não encontrada");
            return conta;
        }
    }
