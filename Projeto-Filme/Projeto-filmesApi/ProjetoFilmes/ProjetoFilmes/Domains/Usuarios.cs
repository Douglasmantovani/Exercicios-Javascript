﻿using System;
using System.Collections.Generic;

namespace ProjetoFilmes.Domains
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Permissao { get; set; }
    }
}
