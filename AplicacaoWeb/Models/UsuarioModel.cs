﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacaoWeb.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

    }
}