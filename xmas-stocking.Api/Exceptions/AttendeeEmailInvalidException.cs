namespace xmas_stocking.Api.Exceptions
{
    public class AttendeeEmailInvalidException : XmasStockingException
    {
        public AttendeeEmailInvalidException() : base("Attendee email is in invalid format!")
        {
        }
    }
}
