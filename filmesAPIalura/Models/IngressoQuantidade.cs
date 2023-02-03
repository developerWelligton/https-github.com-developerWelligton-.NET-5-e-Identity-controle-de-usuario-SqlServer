using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace filmesAPIalura.Models
{
    public class IngressoQuantidade
    {  
        public int SessaoId { get; set; }

        public int Total { get; set; }
        
    }
}
