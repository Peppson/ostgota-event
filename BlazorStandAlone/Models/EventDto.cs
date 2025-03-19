using System.ComponentModel.DataAnnotations;

namespace BlazorStandAlone.Models;

public class EventDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters")]
    public required string Name { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    [StringLength(100, ErrorMessage = "Description cannot be longer than 100 characters")]
    public required string Description { get; set; }
    
    [Required(ErrorMessage = "City is required")]
    [StringLength(40, ErrorMessage = "City cannot be longer than 40 characters")]
    public required string City { get; set; }
    
    [Required(ErrorMessage = "Address is required")]
    [StringLength(40, ErrorMessage = "Address cannot be longer than 40 characters")]
    public required string Address { get; set; }
    
    [Required(ErrorMessage = "Access type is required"), EnumDataType(typeof(AccessType), ErrorMessage = "Invalid access type")]
    public AccessType AccessType { get; set; }
    
    [Required(ErrorMessage = "Start time is required")]
    public DateTime StartTime { get; set; }
    
    [Required(ErrorMessage = "End time is required")]
    public DateTime EndTime { get; set; }
    
    [Range(0, int.MaxValue, ErrorMessage = "Maximum tickets must be a positive number")]
    public int? TicketsMax { get; set; }
    
    [Range(0, int.MaxValue, ErrorMessage = "Tickets sold must be a positive number")]
    public int TicketsSold { get; set; }
    
    [Required(ErrorMessage = "HasSeat value is required")]
    public bool HasSeat { get; set; }
    
    [Required(ErrorMessage = "Image path is required")]
    public required string ImagePath { get; set; } 
}

