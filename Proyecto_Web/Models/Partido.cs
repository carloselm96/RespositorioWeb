﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Web.Models
{
    public class Partido
    {
        public int id { get; set; }
        public String fecha { get; set; }
        public string hora { get; set; }
        public Disciplina disciplina { get; set; }
        public Equipo equipo1 { get; set; }
        public Equipo equipo2 { get; set; }
        public Ubicacion ubicacion { get; set; }
        public Evento evento { get; set; }
    }
}
