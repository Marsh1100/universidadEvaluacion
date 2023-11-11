using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class GradeDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    
}
