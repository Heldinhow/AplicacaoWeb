using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public class Retorno
    {
        public Object Objeto { get; set; }
        public Boolean Valido { get; set; }
        public Exception Excecao { get; set; }
        public List<String> Mensagens { get; set; }
        public static Retorno RetornoSucesso(dynamic objeto)
        {
            Retorno retorno = new Retorno();
            retorno.Objeto = objeto;
            retorno.Valido = true;

            return retorno;
        }
        public static Retorno RetornoErroException(Exception ex)
        {
            Retorno retorno = new Retorno();
            retorno.Mensagens = new List<string> { ex?.Message };
            retorno.Valido = false;
            retorno.Excecao = ex;

            return retorno;
        }
        public static Retorno RetornoErroTratado(List<string> mensagens, bool Valido)
        {
            Retorno retorno = new Retorno();
            retorno.Valido = Valido;
            retorno.Mensagens = mensagens;

            return retorno;
        }
    }
}
