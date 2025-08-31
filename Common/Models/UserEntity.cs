namespace Common.Models
{
    public class UserEntity
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

        public string? Class { get; set; }

        public string? DivisionName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? FamilyId { get; set; }

        public string? ReferenceId { get; set; }

        public bool? IsActive { get; set; }

        public Guid? Mmid { get; set; }

        public string? ImageUrl { get; set; }

        public string? Title { get; set; }

        public string? Relationship { get; set; }

        public string? Country { get; set; }

        public string? Childs { get; set; }

        public bool IsPrinted { get; set; }
        public string? CardNumber { get; set; }
    }
}
