using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Departament : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
