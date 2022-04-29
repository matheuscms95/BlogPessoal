using BlogPessoal.src.data;
using BlogPessoal.src.modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BlogPessoalTeste.Testes.data
{
    [TestClass]
    public class BlogPessoalContextoTeste
    {
        private BlogPessoalContexto _contexto;
            
        [TestInitialize]
        public void inicio()
        {
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>().
                UseInMemoryDatabase(databaseName: "db_blogpessoal")
                .Options;

            _contexto = new BlogPessoalContexto(opt);
        }
        
        [TestMethod]
        public void InserirNovoUsuarioNoBancoRetornarUsuario()
        {
            UsuarioModelo usuario = new UsuarioModelo();

            usuario.Nome = "Matheus Correia";
            usuario.Email = "matheus@email.com";
            usuario.Senha = "587469321";
            usuario.Foto = "AquiVaiOLinkDaFoto";

            _contexto.Usuarios.Add(usuario) //Adicionando usuário

            _contexto.SaveChanges(); //Commita as alterações

            Assert.IsNotNull(_contexto.Usuarios.FirstOrDefault(u => u.Email == "matheus@email.com"));
        }
    }
}
