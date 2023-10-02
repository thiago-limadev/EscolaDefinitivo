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

        public Usuario BuscarPorEmailELogin(string email, string login)
        {
            return _escolaContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public List<Usuario> ListarTodos()
        {
            return _escolaContext.Usuarios.ToList();
        }
        public Usuario Adicionar(Usuario usuario)
        {
            // Grava no banco
            usuario.DatadeCadastro = DateTime.Now;
            usuario.SetSenhaHash();
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

        public Usuario AlterarSenha(AlterarSenhaModel alterarSenhaModel) 
        {
            Usuario usuarioDB = BuscarporId(alterarSenhaModel.Id);

            if(usuarioDB == null) throw new Exception("Houve um erro na atualização da senha, usuário não encontrado!");

            if(!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual inválida, por favor verifique a senha informada!");

            if(usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova Senha deve ser diferente da senha atual!");

            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
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
