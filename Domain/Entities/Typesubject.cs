using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Typesubject : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
