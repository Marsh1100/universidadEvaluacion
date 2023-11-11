using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class AddStudentDto
{
    [Required]
    public int IdPerson { get; set; }
    [Required]
    public int IdSubject { get; set; }
    [Required]
    public int IdSchoolyear { get; set; }
    
}
