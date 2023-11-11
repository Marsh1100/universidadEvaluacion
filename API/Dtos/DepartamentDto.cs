using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class DepartamentDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }   
}

public class DepartamentSubjectDto
{
    public string Departament { get; set; }   
    public string Subject { get; set; }   

    public int Id { get; set; }

}