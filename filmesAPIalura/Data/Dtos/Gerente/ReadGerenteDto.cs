﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;

namespace filmesAPIalura.Data.Dtos.Gerente
{
    public class ReadGerenteDto
    {
        public int Id{get;set;}
        public string Nome { get; set; }

        public object Cinemas { get; set; }

    }
}
