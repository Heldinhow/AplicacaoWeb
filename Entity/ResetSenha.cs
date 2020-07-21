using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ResetSenha
    {
        public int ID_RESET_SENHA { get; set; }
        public int ID_USUARIO { get; set; }
        public string DS_GUID { get; set; }
        public DateTime DT_SOLICITACAO { get; set; }
        public bool FL_ATIVO { get; set; }
    }
}
