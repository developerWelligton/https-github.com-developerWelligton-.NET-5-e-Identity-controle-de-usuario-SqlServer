using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace UsuarioApi.Models
{
    public class Mensagem
    {
        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }

        [System.Obsolete]
        public Mensagem(IEnumerable<string> destinatario, string assunto, int usuarioId, string codigo)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(d)));
            Assunto = assunto;
            Conteudo = $"http://localhost:7000/ativa?UsuarioId={usuarioId}&CodigoDeAtivacao={codigo}";
        }
        [System.Obsolete]
        public Mensagem(IEnumerable<string> destinatario, string assunto, string codigo)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(d)));
            Assunto = assunto;
            Conteudo = $"{codigo}";
        }
    }
}
