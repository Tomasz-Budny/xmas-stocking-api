﻿namespace xmas_stocking.Api.Models
{
    public class Attendee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public string? PreferredGifts { get; set; }
    }
}
