using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsável por representar ações de CRUD de tema</para>
    /// <para>Criado por: Matheus Correia</para>
    /// <para>Versão: 1.1</para>
    /// <para> 12/05/2022</para>
    /// </summary>
    public interface ITema
    {
        Task NovoTemaAsync(NovoTemaDTO tema);
        Task AtualizarTemaAsync(AtualizarTemaDTO tema);
        Task DeletarTemaAsync(int id);
        Task<TemaModelo> PegarTemaPeloIdAsync(int id);
        Task<List<TemaModelo>> PegarTodosTemasAsync();
        Task<List<TemaModelo>> PegarTemasPelaDescricaoAsync(string descricao);
    }
}