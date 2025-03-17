﻿using System.ComponentModel.DataAnnotations;

namespace BlazorStandAlone.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public List<TicketDto>? Tickets { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserRole Role { get; set; }
    }
}
