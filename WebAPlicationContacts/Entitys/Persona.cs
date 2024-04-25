namespace WebAPlicationContacts.Entitys
{
    public class Persona
    {
        public int Identification { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string BirthDate { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
