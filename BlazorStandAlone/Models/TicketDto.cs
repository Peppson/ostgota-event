using System.ComponentModel.DataAnnotations;

namespace BlazorStandAlone.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        public int EventId { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }
        public string? Seat { get; set; }
    }
}
