namespace xmas_stocking.Api.Dtos
{
    public record AttendeeDto(string Name, string Email, string? PreferedGifts = null);
}
