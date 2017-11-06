﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Web.Models
{
    public class Participante
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidop { get; set; }
        public string apellidom { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public Disciplina disciplina { get; set; }
        public Equipo equipo { get; set; }
    }
}