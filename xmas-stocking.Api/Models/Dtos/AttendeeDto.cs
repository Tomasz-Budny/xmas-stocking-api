namespace xmas_stocking.Api.Models.Dtos
{
    public record AttendeeDto(string Name, string Email, string? PreferedGifts = null);
}
