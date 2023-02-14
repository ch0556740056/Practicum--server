using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repositories.Entities;

public partial class Child
{
    [Key]
    public string Identity { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime DateOfBirdth { get; set; }

    public string ParentId { get; set; } = null!;

    public virtual PersonalDetail Parent { get; set; } = null!;
}
