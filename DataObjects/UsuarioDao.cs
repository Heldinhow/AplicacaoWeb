using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class UsuarioDao : ConexaoDao
    {
        public bool NovoUsuario(Usuario usuario)
        {
            int retorno;

            using (var db = base.Conexao)
            {
                retorno = db.Query<int>("PRC_NOVO_USUARIO @DS_USUARIO, @DS_SENHA, @DS_EMAIL_USUARIO", usuario).FirstOrDefault();
            }
            if (retorno == 0)

                return true;
            else
                return false;
        }
        public Usuario BuscarUsuario(Usuario usuario)
        {
            using (var db = base.Conexao)
            {
                return db.Query<Usuario>("PRC_BUSCAR_USUARIO @DS_USUARIO, @DS_SENHA, @DS_EMAIL_USUARIO", usuario).FirstOrDefault();
            }
        }
        public bool UsuarioValido(Usuario usuario)
        {
            Usuario user = new Usuario();
            using (var db = base.Conexao)
            {
                string query = @"SELECT * FROM TB_USUARIO WHERE DS_USUARIO = @DS_USUARIO";
                user = db.Query<Usuario>(query, usuario).FirstOrDefault();
            }
            if (user != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
