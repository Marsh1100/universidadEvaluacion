using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class SubjectDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public float Credit { get; set; }
    [Required]
    public int IdTypesubject { get; set; }
    [Required]
    public sbyte Course { get; set; }
    [Required]
    public sbyte FourMonthPeriod { get; set; }
    [Required]
    public int? IdTeacher { get; set; }
    [Required]
    public int IdGrade { get; set; }


    
}
