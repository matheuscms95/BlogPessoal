using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsável por representar ações de CRUD de postagem</para>
    /// <para>Criado por: Matheus Correia</para>
    /// <para>Versão: 1.1</para>
    /// <para> 12/05/2022</para>
    /// </summary>
    public interface IPostagem
    {   
        Task NovaPostagemAsync(NovaPostagemDTO postagem);
        Task AtualizarPostagemAsync(AtualizarPostagemDTO postagem);
        Task DeletarPostagemAsync(int id);
        Task<PostagemModelo> PegarPostagemPeloIdAsync(int id);
        Task<List<PostagemModelo>> PegarTodasPostagensAsync();
        Task<List<PostagemModelo>> PegarPostagensPorPesquisaAsync(string titulo, string descricaoTema, string nomeCriador);
    }
}
