namespace Common.Models;

public class SchoolModels
{
    public class Contact
    {
        public int Id { get; set; }
        public string? Forename { get; set; }
        public string? MiddleNames { get; set; }
        public string? Surname { get; set; }
        public string? Title { get; set; }
        public string? EmailAddress { get; set; }
        public string? Telephone { get; set; }
        public string? Relationship { get; set; }
        public string? Country { get; set; }
        public List<string> PupilIds { get; set; } = new();
    }

    public class Pupil
    {
        // Attributes
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Guid PersonGuid { get; set; }
        public int DivisionId { get; set; }
        public int AcademicHouseId { get; set; }

        // Elements
        public string? SchoolCode { get; set; }
        public string? SchoolId { get; set; }
        public string? Title { get; set; }
        public string? Forename { get; set; }
        public string? Surname { get; set; }
        public string? Middlename { get; set; }
        public string? Initials { get; set; }
        public string? Preferredname { get; set; }
        public string? Fullname { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? AcademicHouse { get; set; }
        public string? Form { get; set; }
        public string? NCYear { get; set; }
        public string? DivisionName { get; set; }
        public string? EmailAddress { get; set; }
        public string? MobileNumber { get; set; }
        public string? PupilType { get; set; }
        public DateTime? EnrolmentDate { get; set; }
        public string? EnrolmentTerm { get; set; }
        public string? EnrolmentSchoolYear { get; set; }
        public string? FamilyId { get; set; }
        public string? Nationalities { get; set; }
        public string? Languages { get; set; }
        public string? Tutor { get; set; }
    }

    public class Staff
    {
        public int Id { get; set; }
        public string? Forename { get; set; }
        public string? Surname { get; set; }
        public string? Title { get; set; }
        public string? EmailAddress { get; set; }
        public List<string> Roles { get; set; } = new();
    }

    public class YearGroup
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class SchoolData
    {
        public List<Contact> Contacts { get; set; } = new();
        public List<Pupil> Pupils { get; set; } = new();
        public List<Staff> StaffMembers { get; set; } = new();
        public List<YearGroup> YearGroups { get; set; } = new();
    }
}