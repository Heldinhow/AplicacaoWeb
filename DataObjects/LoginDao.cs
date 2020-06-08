using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class LoginDao : ConexaoDao
    {
        public Usuario BuscarUsuario(string usuario, string senha)
        {
            using (var con = base.Conexao)
            {
                Usuario u = new Usuario();
                return u;

            }
        }
    }
}
