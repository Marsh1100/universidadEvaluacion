using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Typeperson : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
