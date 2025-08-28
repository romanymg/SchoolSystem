using System;
using System.Collections.Generic;

namespace DAL;

public partial class User
{
    public long Id { get; set; }

    public int? UserTypeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public string? ThirdName { get; set; }

    public string? FourthName { get; set; }

    public string? FullName { get; set; }

    public string UserCode { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? Dob { get; set; }

    public string? AcademicHouse { get; set; }

    public string? Class { get; set; }

    public string? DivisionName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public long? FamilyId { get; set; }

    public string? Nationalities { get; set; }

    public string? Languages { get; set; }

    public string? Tutor { get; set; }

    public long? RefUserId { get; set; }

    public long? ParentId { get; set; }

    public bool? IsActive { get; set; }

    public Guid? Mmid { get; set; }

    public DateTime? InsertDate { get; set; }

    public string? ImageUrl { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<User> InverseParent { get; set; } = new List<User>();

    public virtual MediaFile? Mm { get; set; }

    public virtual User? Parent { get; set; }

    public virtual UserType? UserType { get; set; }
}
