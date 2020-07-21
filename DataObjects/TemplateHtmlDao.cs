using Dapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class TemplateHtmlDao : ConexaoDao
    {
        public Template BuscarTemplate()
        {
            using (var con = base.Conexao)
            {
                return con.Query<Template>("SELECT HTML_TEMPLATE FROM TB_TEMPLATE_EMAIL").FirstOrDefault();
            }
        }
    }
}
