using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TourDe.Models;

[Index(nameof(Email), IsUnique=true)]
public class Person
{ 
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, StringLength(50, MinimumLength = 3)]
    public string FirstName { get; set; }

    [Required, StringLength(50, MinimumLength = 3)]
    public string LastName { get; set; }
    
    public DateTime? DateOfBirth { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }
    
    public string? Phone { get; set; }
}