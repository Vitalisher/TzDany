using System.ComponentModel.DataAnnotations;

namespace PersonalAccount.API.Models;

public class Account 
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(10, MinimumLength = 10, 
        ErrorMessage = "Лицевой счет должен состоять из 10 цифр")]
    public string? AccountNumber { get; set; } 
    
    [Required]
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public Address? Address { get; set; }
    
    public float Area { get; set; }
    
    public ICollection<Resident>? Residents { get; set; }
}