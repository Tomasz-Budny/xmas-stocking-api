namespace xmas_stocking.Api.Models
{
    public class AttendeeWithSelectedAtendee : Attendee
    {
        public Attendee RandomlySelectedAttendee { get; set; }
    }
}
