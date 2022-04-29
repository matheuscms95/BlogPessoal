﻿using System.ComponentModel.DataAnnotations;

namespace BlogPessoal.src.dtos
{
    /// <summary>
    /// <para>Resumo: Classe espelho para criar um novo usuário</para>
    /// <para>Criado por: Matheus Correia</para>
    /// <para>Versão: 1.0</para>
    /// <para> 29/04/2022</para>
    /// </summary>
    public class NovoUsuarioDTO
    {
        [Required, StringLength(50)]
        public string Nome { get; set; }

        [Required, StringLength(30)]
        public string Email { get; set; }
        
        [Required, StringLength(30)]
        public string Senha { get; set; }
        
        public string Foto { get; set; }

        public NovoUsuarioDTO(string nome, string email, string senha, string foto)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Foto = foto;
        }
    }

    /// <summary>
    /// <para>Resumo: Classe espelho para atualizar um usuário</para>
    /// <para>Criado por: Matheus Correia</para>
    /// <para>Versão: 1.0</para>
    /// <para> 29/04/2022</para>
    /// </summary>
    public class AtualizarUsuarioDTO
    {
        [Required, StringLength(50)]
        public string Nome { get; set; }
        [Required, StringLength(30)]
        public string Senha { get; set; }
        public string Foto { get; set; }

        public AtualizarUsuarioDTO(string nome, string senha, string foto)
        {
            Nome = nome;
            Senha = senha;
            Foto = foto;
        }
    }
}
