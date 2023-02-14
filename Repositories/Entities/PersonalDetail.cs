using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repositories.Entities;

public partial class PersonalDetail
{

    [Key]
    public string Identity { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Gender { get; set; }

    public string? Hmo { get; set; }

    public DateTime? DateOfBirdth { get; set; }

    public virtual ICollection<Child> Children { get; } = new List<Child>();
}
