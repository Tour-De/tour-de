using System.ComponentModel.DataAnnotations;

namespace TourDe.Models;

public class Location
{
    [Key]
    public int Id { get; set; }

    public string Description { get; set; }
}