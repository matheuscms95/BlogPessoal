using BlogPessoal.src.dtos;
using BlogPessoal.src.modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogPessoal.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Responsável por representar ações de CRUD de usuário</para>
    /// <para>Criado por: Matheus Correia</para>
    /// <para>Versão: 1.1</para>
    /// <para> 12/05/2022</para>
    /// </summary>
    public interface IUsuario
    {
        Task NovoUsuarioAsync(NovoUsuarioDTO usuario);
        Task AtualizarUsuarioAsync(AtualizarUsuarioDTO usuario);
        Task DeletarUsuarioAsync(int id);
        Task<UsuarioModelo> PegarUsuarioPeloIdAsync(int id);
        Task<UsuarioModelo> PegarUsuarioPeloEmailAsync(string email);
        Task<List<UsuarioModelo>> PegarUsuariosPeloNomeAsync(string nome);
    }
}