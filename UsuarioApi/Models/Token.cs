namespace UsuarioApi.Models
{
    public class Token
    {
        public string value { get; }
        public Token(string value) { 
            this.value = value;
        }
       
    }
}
