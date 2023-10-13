namespace xmas_stocking.Api.Models
{
    public class Attendee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PreferredGifts { get; set; } = null;
    }
}
