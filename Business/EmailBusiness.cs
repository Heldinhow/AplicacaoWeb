using Entity;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EmailBusiness
    {
        public Retorno EnviarEmail(Usuario usuario)
        {

            var template = (Template)new TemplateHtmlBusiness().BuscarTemplate().Objeto;

            string text = template.HTML_TEMPLATE.Replace("[USUARIO]", usuario.DS_USUARIO);
            string link = @"https://localhost:44333/Login/AlterarSenha?codigo=" + usuario.DS_GUID;
            string html = text.Replace("{{reset_password_link}}", link);
            try
            {
                MailMessage msg = null;
                msg = new MailMessage("naoresponsaxpto@gmail.com", usuario.DS_EMAIL_USUARIO, "Recuperação de Senha", html);
                msg.IsBodyHtml = true;
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("naoresponsaxpto@gmail.com", "hahadown123"),
                    EnableSsl = true,
                })
                {
                    client.Send(msg);
                }

                return Retorno.RetornoSucesso(usuario);
            }
            catch (Exception ex)
            {
                return Retorno.RetornoErroException(ex);
            }
        }
    }
}
