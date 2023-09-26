using EscolaDefinitivo.Data;
using EscolaDefinitivo.Models;

namespace EscolaDefinitivo.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly EscolaContext _escolaContext;
        
        public UsuarioRepositorio(EscolaContext escolaContext)
        {
            _escolaContext = escolaContext;
        }

        public Usuario BuscarPorLogin(string login)
        {
            return _escolaContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public Usuario BuscarporId(int id)
        {
            return _escolaContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<Usuario> ListarTodos()
        {
            return _escolaContext.Usuarios.ToList();
        }
        public Usuario Adicionar(Usuario usuario)
        {
            // Grava no banco
            usuario.DatadeCadastro = DateTime.Now;
            _escolaContext.Usuarios.Add(usuario);
            _escolaContext.SaveChanges();

            return (usuario);

        }

        public Usuario Atualizar(Usuario usuario)
        {
           Usuario usuarioDB = BuscarporId(usuario.Id);

            if (usuarioDB == null) throw new Exception("Houve um erro ao tentar atualizar o Usuário");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DatadeAtualizacao = DateTime.Now;

            _escolaContext.Usuarios.Update(usuarioDB);
            _escolaContext.SaveChanges();

            return usuarioDB;

        }


       
        public bool Apagar(int id)
        {
            Usuario usuarioDB = BuscarporId(id);

            if (usuarioDB == null) throw new Exception("Houve um erro ao tentar excluir o Usuário");


            _escolaContext.Usuarios.Remove(usuarioDB);
            _escolaContext.SaveChanges();

            return true;

        }
    }
}
