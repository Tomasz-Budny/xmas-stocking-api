namespace xmas_stocking.Api.Exceptions
{
    public class AttendeNameIsTooShortException : XmasStockingException
    {
        public AttendeNameIsTooShortException(int nameMinLength) : base($"Attende name is too short! Minimum length {nameMinLength}.") { }
    }
}
