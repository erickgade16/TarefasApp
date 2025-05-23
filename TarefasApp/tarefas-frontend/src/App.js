import React, { useEffect, useState } from 'react';
import axios from 'axios';

function App() {
  const [tarefas, setTarefas] = useState([]);
  const [titulo, setTitulo] = useState('');
  const [descricao, setDescricao] = useState('');
  const [concluida, setConcluida] = useState(false);
  const [loading, setLoading] = useState(false);
  const [editandoId, setEditandoId] = useState(null); // Id da tarefa que está editando

  // Buscar tarefas da API
  const fetchTarefas = async () => {
    setLoading(true);
    try {
      const response = await axios.get('http://localhost:5270/api/tarefas');
      setTarefas(response.data);
    } catch (error) {
      alert('Erro ao carregar tarefas');
    }
    setLoading(false);
  };

  useEffect(() => {
    fetchTarefas();
  }, []);

  // Criar ou atualizar tarefa
  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!titulo.trim()) {
      alert('Título é obrigatório');
      return;
    }

    const tarefaData = {
      titulo,
      descricao,
      concluida,
      dataCriacao: new Date().toISOString()
    };

    try {
      if (editandoId) {
        // Atualizar
        await axios.put(`http://localhost:5270/api/tarefas/${editandoId}`, tarefaData);
        setEditandoId(null);
      } else {
        // Criar
        await axios.post('http://localhost:5270/api/tarefas', tarefaData);
      }
      setTitulo('');
      setDescricao('');
      setConcluida(false);
      fetchTarefas();
    } catch (error) {
      alert('Erro ao salvar tarefa');
    }
  };

  // Preparar formulário para editar tarefa
  const editarTarefa = (tarefa) => {
    setTitulo(tarefa.titulo);
    setDescricao(tarefa.descricao);
    setConcluida(tarefa.concluida);
    setEditandoId(tarefa.id);
  };

  // Cancelar edição
  const cancelarEdicao = () => {
    setTitulo('');
    setDescricao('');
    setConcluida(false);
    setEditandoId(null);
  };

  // Excluir tarefa
  const excluirTarefa = async (id) => {
    if (window.confirm('Tem certeza que deseja excluir essa tarefa?')) {
      try {
        await axios.delete(`http://localhost:5270/api/tarefas/${id}`);
        fetchTarefas();
      } catch (error) {
        alert('Erro ao excluir tarefa');
      }
    }
  };

  return (
    <div className="container mt-5">
      <h1 className="mb-4">Lista de Tarefas</h1>

      <form onSubmit={handleSubmit} className="mb-4 p-4 border rounded bg-light">
        <div className="mb-3">
          <label htmlFor="titulo" className="form-label">Título</label>
          <input
            type="text"
            id="titulo"
            className="form-control"
            value={titulo}
            onChange={e => setTitulo(e.target.value)}
            placeholder="Digite o título da tarefa"
          />
        </div>
        <div className="mb-3">
          <label htmlFor="descricao" className="form-label">Descrição</label>
          <textarea
            id="descricao"
            className="form-control"
            value={descricao}
            onChange={e => setDescricao(e.target.value)}
            placeholder="Digite uma descrição (opcional)"
          />
        </div>
        <div className="form-check mb-3">
          <input
            type="checkbox"
            id="concluida"
            className="form-check-input"
            checked={concluida}
            onChange={e => setConcluida(e.target.checked)}
          />
          <label htmlFor="concluida" className="form-check-label">Concluída</label>
        </div>
        <button type="submit" className="btn btn-primary me-2">
          {editandoId ? 'Atualizar Tarefa' : 'Adicionar Tarefa'}
        </button>
        {editandoId && (
          <button type="button" className="btn btn-secondary" onClick={cancelarEdicao}>
            Cancelar
          </button>
        )}
      </form>

      {loading ? (
        <div>Carregando tarefas...</div>
      ) : (
        <ul className="list-group">
          {tarefas.map(tarefa => (
            <li
              key={tarefa.id}
              className={`list-group-item d-flex justify-content-between align-items-center ${
                tarefa.concluida ? 'list-group-item-success' : ''
              }`}
            >
              <div>
                <h5>{tarefa.titulo}</h5>
                <p className="mb-1">{tarefa.descricao}</p>
                <small>Criada em: {new Date(tarefa.dataCriacao).toLocaleString()}</small>
              </div>
              <div>
                <button
                  className="btn btn-sm btn-warning me-2"
                  onClick={() => editarTarefa(tarefa)}
                >
                  Atualizar
                </button>
                <button
                  className="btn btn-sm btn-danger"
                  onClick={() => excluirTarefa(tarefa.id)}
                >
                  Excluir
                </button>
              </div>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default App;
