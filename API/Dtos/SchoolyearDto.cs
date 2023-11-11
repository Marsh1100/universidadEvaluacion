using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class SchoolyearDto
{
    public int Id { get; set; }
    [Required]
    public short YearStart { get; set; }
    [Required]
    public short YearEnd { get; set; }

    
}
