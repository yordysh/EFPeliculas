﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class Genero
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }
    }
}
