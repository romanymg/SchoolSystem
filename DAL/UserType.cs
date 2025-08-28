using System;
using System.Collections.Generic;

namespace DAL;

public partial class UserType
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
