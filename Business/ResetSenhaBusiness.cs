using Entity;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using Macoratti.EnviaEmail;
using System.Net.Mail;
using System.Net;

namespace Business
{
    public class ResetSenhaBusiness
    {
        public Retorno SolicitarReset(Usuario usuario)
        {
            try
            {
                var retorno = new ResetSenhaDao().SolicitarReset(usuario);
                if (retorno != null)
                {
                    new EmailBusiness().EnviarEmail(retorno);
                    return Retorno.RetornoSucesso(retorno);
                }
                else
                    return Retorno.RetornoErroTratado(new List<string> { "O login informado não está disponível." }, false);

            }
            catch (Exception ex)
            {
                return Retorno.RetornoErroException(ex);
            }

        }

    }
}
