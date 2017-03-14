namespace Senserv.Model
{
    public class EmailAddress
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public EmailAddress(){}
        public EmailAddress(string email, string name = null)
        {
            Email = email;
            Name = name;
        }
    }
}
