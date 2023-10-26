namespace xmas_stocking.DAL.Persistance.Models
{
    public class Draw
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public IEnumerable<GiftPresenter> Attendees { get; set; }
        public int NumberOfAttendees { get; set; }
    }
}
