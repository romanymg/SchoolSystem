using System;
using System.Collections.Generic;

namespace DAL;

public partial class UserRelation
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public int? UserId { get; set; }
}
