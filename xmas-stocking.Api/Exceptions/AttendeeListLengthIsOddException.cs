namespace xmas_stocking.Api.Exceptions
{
    public class AttendeeListLengthIsOddException : XmasStockingException
    {
        public AttendeeListLengthIsOddException() : base("Attendee list length is odd!")
        {
        }
    }
}
