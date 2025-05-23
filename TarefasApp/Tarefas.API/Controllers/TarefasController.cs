using Microsoft.AspNetCore.Mvc;
using Tarefas.Application.Services;
using Tarefas.Domain.Entities;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{
    private readonly TarefaService _tarefaService;

    
    public TarefasController(TarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tarefas = await _tarefaService.ObterTodasAsync();
        return Ok(tarefas);
    }

    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tarefa = await _tarefaService.ObterPorIdAsync(id);
        if (tarefa == null)
        {
            return NotFound();
        }
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Tarefa tarefa)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var novaTarefa = await _tarefaService.AdicionarAsync(tarefa);
        return CreatedAtAction(nameof(GetById), new { id = novaTarefa.Id }, novaTarefa);
    }

    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] Tarefa tarefa)
    {
        if (id != tarefa.Id || !ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _tarefaService.AtualizarAsync(tarefa);
        return NoContent();
    }


    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var tarefa = await _tarefaService.ObterPorIdAsync(id);
        if (tarefa == null)
        {
            return NotFound();
        }
        await _tarefaService.DeletarAsync(id);
        return NoContent();
    }
};

