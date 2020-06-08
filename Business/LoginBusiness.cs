using DataObjects;
using Entity;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LoginBusiness
    {
        public Retorno EfetuarLogin(string usuario, string senha)
        {
            try
            {
                Usuario user = new LoginDao().BuscarUsuario(usuario, senha);
                return Retorno.RetornoSucesso(user);
            }
            catch (Exception ex)
            {
                return Retorno.RetornoErroException(ex);
            }
        }
    }
}
