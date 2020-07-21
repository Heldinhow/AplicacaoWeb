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
                    SendMail(retorno);
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
        public Retorno SendMail(Usuario usuario)
        {
            var template = (Template) new TemplateHtmlBusiness().BuscarTemplate().Objeto;

            string text = template.HTML_TEMPLATE.Replace("[USUARIO]", usuario.DS_USUARIO);

            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("naoresponsaxpto@gmail.com", "hahadown123"),
                EnableSsl = true
            })
            {
                client.Send("naoresponsaxpto@gmail.com", usuario.DS_EMAIL_USUARIO, "Recuperação de Senha", text);
            }
            return Retorno.RetornoSucesso(usuario);
        }
    }
}
