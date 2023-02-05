using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace filmesAPIalura.Models
{
    public class Ingresso
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [JsonIgnore]
        public virtual Sessao Sessao { get; set; }

        public int SessaoId { get; set; }
          

    }
}
