using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Studenttuition : BaseEntity
{
    public int IdPerson { get; set; }

    public int IdSubject { get; set; }

    public int IdSchoolyear { get; set; }

    public virtual Person Person { get; set; }

    public virtual Schoolyear Schoolyear { get; set; }

    public virtual Subject Subject { get; set; }
}
