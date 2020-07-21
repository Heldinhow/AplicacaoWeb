using DataObjects;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class TemplateHtmlBusiness
    {
        public Retorno BuscarTemplate()
        {
            var retorno = new TemplateHtmlDao().BuscarTemplate();
            if(retorno != null)
            {
                return Retorno.RetornoSucesso(retorno);

            }
            else
                return Retorno.RetornoErroTratado(new List<string> { "O login informado não está disponível." }, false);

        }
    }
}
