using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Usuario
    {
        public int ID_USUARIO { get; set; }
        public string DS_USUARIO { get; set; }
        public string DS_SENHA { get; set; }
        public string DS_EMAIL_USUARIO { get; set; }
        public DateTime DT_INCLUSAO { get; set; }
        public int TIPO_PERFIL { get; set; }
    }
}
