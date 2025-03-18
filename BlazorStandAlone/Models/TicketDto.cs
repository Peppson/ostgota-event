using System.ComponentModel.DataAnnotations;

namespace BlazorStandAlone.Models
{
    public class TicketDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "User ID must be greater than 0")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Event ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Event ID must be greater than 0")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; } 

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }

        [StringLength(10, ErrorMessage = "Seat number cannot be longer than 10 characters")]
        public string? Seat { get; set; }
    }
}
