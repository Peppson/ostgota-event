using Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Blazor.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public required User User { get; set; }
        [Required]
        public int EventId { get; set; }
        public required Event Event { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string? Seat { get; set; }
        public string Title { get; set; }
    }
}
