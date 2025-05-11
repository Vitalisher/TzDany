using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PersonalAccount.API.Models;

public class Resident
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(20)]
    public string? FirstName { get; set; }
    
    [Required]
    [StringLength(20)]
    public string? LastName { get; set; }
    
    [Required]
    [StringLength(20)]
    public string? MiddleName { get; set; }
    
    [ForeignKey(nameof(Account))]
    public int PersonalAccountId { get; set; }
    
    [JsonIgnore]
    public Account? PersonalAccount { get; set; }
}