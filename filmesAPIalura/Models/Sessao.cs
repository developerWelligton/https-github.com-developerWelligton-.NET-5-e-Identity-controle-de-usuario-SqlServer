using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FilmesAPI.Models;

namespace filmesAPIalura.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }

        public DateTime HorarioDeEncerramento { get; set; }
        [JsonIgnore]
        public virtual List<Ingresso> Ingressos { get; set; } 
    }
}
