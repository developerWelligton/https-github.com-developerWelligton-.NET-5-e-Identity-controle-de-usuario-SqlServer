 
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using UsuarioApi.Models;

namespace UsuarioApi.Services
{
    public class EmailService
    {
        private IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [Obsolete]
        public void EnviarEmail(string[] destinatario, string assunto, int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);
            var mensagemDeEmail = CriaCorpoDoEmail(mensagem);
            Enviar(mensagemDeEmail);
        }

        [Obsolete]
        public void EnviarEmailRecuperacaoSenha(string[] destinatario, string assunto, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, code);
            var mensagemDeEmail = CriaCorpoDoEmail(mensagem);
            Enviar(mensagemDeEmail);
        }

        private void Enviar(MimeMessage mensagemDeEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        configuration.GetValue<int>("EmailSettings:Port"), MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable
                        );
                    client.AuthenticationMechanisms.Remove("XOUATH2");
                    client.Authenticate(configuration.GetValue<string>("EmailSettings:From"),
                        configuration.GetValue<string>("EmailSettings:Password")
                        );
                    //TODO  Auth de e-mail


                    client.Send(mensagemDeEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        [Obsolete]
        private MimeMessage CriaCorpoDoEmail(Mensagem mensagem)
        {
            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress(configuration.GetValue<string>("EmailSettings:From")));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };
            return mensagemDeEmail;
        }
    }
}
