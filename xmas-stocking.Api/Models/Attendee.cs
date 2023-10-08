namespace xmas_stocking.Api.Models
{
    public class Attendee
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string RandomlySelectedAttendeeName { get; set; }

        public Attendee(string name, string email, string randomlySelectedAttendeeName)
        {
            Name = name;
            Email = email;
            RandomlySelectedAttendeeName = randomlySelectedAttendeeName;
        }
    }
}
