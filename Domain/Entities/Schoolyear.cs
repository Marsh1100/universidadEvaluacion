using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Entities;

public partial class Schoolyear : BaseEntity
{
    public short YearStart { get; set; }
    public short YearEnd { get; set; }
}
