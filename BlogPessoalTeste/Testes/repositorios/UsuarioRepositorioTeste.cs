using BlogPessoal.src.data;
using BlogPessoal.src.dtos;
using BlogPessoal.src.repositorios;
using BlogPessoal.src.repositorios.implementacoes;
using BlogPessoal.src.utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPessoalTeste.Testes.repositorios
{
    [TestClass]
    public class UsuarioRepositorioTeste
    {
        private BlogPessoalContexto _contexto;
        private IUsuario _repositorio;

        [TestMethod]
        public async Task CriarQuatroUsuariosNoBancoRetornaQuatroUsuarios()
        {
            // Definindo o contexto
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase("CriarQuatroUsuariosNoBancoRetornaQuatroUsuarios")
                .Options;

            _contexto = new BlogPessoalContexto(opt);
            _repositorio = new UsuarioRepositorio(_contexto);

            //GIVEN - Dado que registro 4 usuarios no banco
            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO(
                    "Zeca Junior",
                    "zecajunior@domain.com",
                    "123456",
                    "URLFOTO",
                    TipoUsuario.NORMAL));

            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO(
                    "Tamara Estevam",
                    "tamaraestevam@domain.com",
                    "789456",
                    "URLFOTO",
                    TipoUsuario.NORMAL));

            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO(
                    "Gilmar Santos",
                    "gilmarsantos@domain.com",
                    "326598",
                    "URLFOTO",
                    TipoUsuario.NORMAL));

            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO(
                    "Adelina Santos",
                    "adelinasantos@domain.com",
                    "124578",
                    "URLFOTO",
                    TipoUsuario.NORMAL));

            //WHEN - Quando pesquiso lista total
            //THEN - Então recebo 4 usuarios
            Assert.AreEqual(4, _contexto.Usuarios.Count());
        }

        [TestMethod]
        public async Task PegarUsuarioPeloEmailRetornaNaoNulo()
        {
            // Definindo o contexto
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
            .UseInMemoryDatabase(databaseName: "db_blogpessoal2")
            .Options;

            _contexto = new BlogPessoalContexto(opt);
            _repositorio = new UsuarioRepositorio(_contexto);

            //GIVEN - Dado que registro um usuario no banco
            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO(
                    "Juliana Correia",
                    "julianacorreia@domain.com",
                    "456123",
                    "URLFOTO",
                    TipoUsuario.NORMAL));

            //WHEN - Quando pesquiso pelo email deste usuario
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync("julianacorreia@domain.com");

            //THEN - Então obtenho um usuario
            Assert.IsNotNull(usuario);
        }

        [TestMethod]
        public async Task PegarUsuarioPeloIdRetornaNaoNuloENomeDoUsuario()
        {
            // Definindo o contexto
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal3")
                .Options;

            _contexto = new BlogPessoalContexto(opt);
            _repositorio = new UsuarioRepositorio(_contexto);

            //GIVEN - Dado que registro um usuario no banco
            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO(
                    "Maria Fatima",
                    "mariafatima@domain.com",
                    "123456",
                    "URLFOTO",
                    TipoUsuario.NORMAL));

            //WHEN - Quando pesquiso pelo id 1
            var usuario = await _repositorio.PegarUsuarioPeloIdAsync(1);

            //THEN - Então, deve me retornar um elemento não nulo
            Assert.IsNotNull(usuario);

            //THEN - Então, o elemento deve ser Neusa Boaz
            Assert.AreEqual("Maria Fatima", usuario.Nome);
        }

        [TestMethod]
        public async Task AtualizarUsuarioRetornaUsuarioAtualizado()
        {
            // Definindo o contexto
            var opt = new DbContextOptionsBuilder<BlogPessoalContexto>()
                .UseInMemoryDatabase(databaseName: "db_blogpessoal4")
                .Options;

            _contexto = new BlogPessoalContexto(opt);
            _repositorio = new UsuarioRepositorio(_contexto);

            //GIVEN - Dado que registro um usuario no banco
            await _repositorio.NovoUsuarioAsync(
                new NovoUsuarioDTO(
                    "Angeles Martinez",
                    "angelesmartinez@domail.com",
                    "123456",
                    "URLFOTO",
                    TipoUsuario.NORMAL));

            //WHEN - Quando atualizamos o usuario
            await _repositorio.AtualizarUsuarioAsync(
                new AtualizarUsuarioDTO(
                    1,
                    "Angeles Martinez",
                    "951487",
                    "URLFOTONOVA"));

            //THEN - Então, quando validamos pesquisa deve retornar nome Angeles Martinez
            var antigo = await _repositorio.PegarUsuarioPeloEmailAsync("angelesmartinez@domail.com");
            
            Assert.AreEqual("Angeles Martinez", _contexto.Usuarios.FirstOrDefault(u => u.Id == antigo.Id).Nome);

            //THEN - Então, quando validamos a pesquisa deve retornar senha 951487
            Assert.AreEqual("951487", _contexto.Usuarios.FirstOrDefault(u => u.Id == antigo.Id).Senha);
        }
    }
}