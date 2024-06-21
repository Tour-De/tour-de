using System.ComponentModel.DataAnnotations;

namespace TourDe.Models;

public class Assignment
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public int LocationId { get; set; }
    public Location Location { get; set; }
}