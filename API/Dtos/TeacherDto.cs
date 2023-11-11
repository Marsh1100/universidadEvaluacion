using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class TeacherDto
{
    public int Id { get; set; }
    [Required]
    public int IdPerson { get; set; }

    [Required]
    public int IdDepartament { get; set; }

    
}
