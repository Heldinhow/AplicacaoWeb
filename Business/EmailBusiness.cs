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
            try
            {

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
            catch (Exception ex)
            {
                return Retorno.RetornoErroException(ex);
            }
        }
    }
}
