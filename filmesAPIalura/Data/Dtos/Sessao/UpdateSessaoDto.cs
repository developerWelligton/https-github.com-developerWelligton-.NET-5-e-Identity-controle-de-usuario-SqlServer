using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace filmesAPIalura.Data.Dtos.Sessao
{
    public class UpdateSessaoDto
    {
        [Required(ErrorMessage = "O campo de cinema é obrigatório")]
        public int CinemaId { get; set; }
        [Required(ErrorMessage = "O campo de filme é obrigatório")]
        public int FilmeId { get; set; }
    }
}
