using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Person : BaseEntity
{
    public string Nit { get; set; }

    public string Name { get; set; }

    public string Lastname1 { get; set; }

    public string Lastname2 { get; set; }

    public string City { get; set; }

    public string Address { get; set; }

    public string Phone { get; set; }

    public DateOnly Birthdate { get; set; }

    public int IdGender { get; set; }

    public int IdTypeperson { get; set; }

    public virtual Gender Gender { get; set; }

    public virtual Typeperson Typeperson { get; set; }

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
