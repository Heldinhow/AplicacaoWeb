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
    public class UsuarioBusiness
    {
        public Retorno NovoUsuario(Usuario usuario)
        {
            try
            {

            bool retorno = new UsuarioDao().NovoUsuario(usuario);
                if (retorno)
                {
                    return Retorno.RetornoSucesso(retorno);
                }
                else
                    return Retorno.RetornoErroTratado(new List<string> { "O login informado não está disponível."}, retorno);

            }
            catch(Exception ex)
            {
                return Retorno.RetornoErroException(ex);
            }

        }
        public Retorno BuscarUsuario(Usuario usuario)
        {
            try
            {

                var retorno = new UsuarioDao().BuscarUsuario(usuario);
                if (retorno != null)
                {
                    return Retorno.RetornoSucesso(retorno);
                }
                else
                    return Retorno.RetornoErroTratado(new List<string> { "Usuário ou senha incorreto." }, false); ;

            }
            catch (Exception ex)
            {
                return Retorno.RetornoErroException(ex);
            }
        }
        public Retorno UsuarioValido(string usuario)
        {
            try
            {

                var retorno = new UsuarioDao().UsuarioValido(new Usuario { DS_USUARIO = usuario});
                if (retorno)
                {
                    return Retorno.RetornoErroTratado(new List<string> { "LOGIN NÃO DISPONÍVEL." }, false); ;
                }
                else
                    return Retorno.RetornoSucesso(retorno);

            }
            catch (Exception ex)
            {
                return Retorno.RetornoErroException(ex);
            }
        }
    }
}
