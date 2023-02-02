using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace filmesAPIalura.Data.Dtos.Ingresso
{
    public class CreateIngressoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sessao { get; set; }
        public int SessaoId { get; set; }
       
    }
}
