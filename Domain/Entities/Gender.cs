using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Gender : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
