using System.ComponentModel.DataAnnotations;

namespace PersonalAccount.API.Models;

public class Address
{
    [Required]
    [StringLength(50)]
    public string? City { get; set; }
    
    [Required]  
    [StringLength(50)]
    public string? Street { get; set; }
    
    [Required]  
    [Range(1, 1000)]
    public int HouseNumber { get; set; }
    
    [Required]  
    [Range(1, 1000)]
    public int ApartmentNumber { get; set; }
}