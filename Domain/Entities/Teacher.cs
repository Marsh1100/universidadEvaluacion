using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Teacher : BaseEntity
{

    public int IdPerson { get; set; }

    public int IdDepartament { get; set; }

    public virtual Departament Departament { get; set; }

    public virtual Person Person { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
