using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmesAPIalura.Data.Dtos.Sessao
{
    public class CreateSessaoDto
    {
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HoraDeEncerramento { get; set; }

    }
}
