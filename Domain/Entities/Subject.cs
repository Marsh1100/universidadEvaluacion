using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Subject : BaseEntity
{
    public string Name { get; set; }

    public float Credit { get; set; }

    public int IdTypesubject { get; set; }

    public sbyte Course { get; set; }

    public sbyte FourMonthPeriod { get; set; }

    public int? IdTeacher { get; set; }

    public int IdGrade { get; set; }

    public virtual Grade Grade { get; set; }

    public virtual Teacher Teacher { get; set; }

    public virtual Typesubject Typesubject { get; set; }
}
