using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class PersonDto
{
    public int Id { get; set; }
    [Required]
    public string Nit { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public string Lastname1 { get; set; }
    [Required]
    public string Lastname2 { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public DateOnly Birthdate { get; set; }
    [Required]
    public int IdGender { get; set; }
    [Required]
    public int IdTypeperson { get; set; }
    
}

public class PersonAllDto
{
    public int Id { get; set; }
    public string Nit { get; set; }
    public string Name { get; set; }
    public string Lastname1 { get; set; }
    public string Lastname2 { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public DateOnly Birthdate { get; set; }
    public string Gender { get; set; }
}

public class PersonOnlyNameDto
{
    public string Name { get; set; }
    public string Lastname1 { get; set; }
    public string Lastname2 { get; set; }
}


