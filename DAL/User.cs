using System;
using System.Collections.Generic;

namespace DAL;

public partial class User
{
    public long Id { get; set; }

    public long? ParentId { get; set; }

    public int? UserTypeId { get; set; }

    public string? UserCode { get; set; }

    public string? FullName { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? GenderId { get; set; }

    public DateTime? Dob { get; set; }

    public string? DivisionName { get; set; }

    public string? Class { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? FamilyId { get; set; }

    public string? ReferenceId { get; set; }

    public bool? IsActive { get; set; }

    public Guid? Mmid { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? InsertDate { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Title { get; set; }

    public string? Relationship { get; set; }

    public string? Country { get; set; }

    public string? Childs { get; set; }

    public virtual ICollection<User> InverseParent { get; set; } = new List<User>();

    public virtual MediaFile? Mm { get; set; }

    public virtual User? Parent { get; set; }

    public virtual UserType? UserType { get; set; }
}
