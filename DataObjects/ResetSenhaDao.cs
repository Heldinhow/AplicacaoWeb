using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class ResetSenhaDao : ConexaoDao
    {
        public Usuario SolicitarReset(Usuario usuario)
        {
            using (var con = base.Conexao)
            {
                return con.Query<Usuario>("PRC_RESET_SENHA @ID_USUARIO", usuario).FirstOrDefault();
            }
        }
        public Usuario ValidarCodigo(string codigo)
        {
            using (var con = base.Conexao)
            {
                string query = @"SELECT TOP 1 * FROM TB_RESET_SENHA
                    WHERE FL_ATIVO =1
                    AND DS_GUID = @Codigo
                    ORDER BY DT_SOLICITACAO DESC";
                var ret = con.Query<Usuario>(query, new { Codigo = codigo}).FirstOrDefault();

                return ret;
            }
        }
        public bool AlterarSenha(Usuario usuario)
        {
            using (var con = base.Conexao)
            {
                string query = @"UPDATE TB_USUARIO SET DS_SENHA = @Senha WHERE ID_USUARIO = @IdUsuario";

                var ret = con.Query<int>(query, new { Senha = usuario.DS_SENHA, IdUsuario = usuario.ID_USUARIO}).FirstOrDefault();

                return (ret == 0 ? true : false);

            }
        }
    }
}
