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
    }
}
