﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Actor
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Biografia { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public HashSet<PeliculaActor> PeliculaActores { get; set; }
    }
}
