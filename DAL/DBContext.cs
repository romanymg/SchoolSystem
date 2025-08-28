using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MediaFile> MediaFiles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MediaFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MediaFil__3214EC27E636A10C");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.FileExtension).HasMaxLength(20);
            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.FileType).HasMaxLength(50);
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC077FECF2F6");

            entity.HasIndex(e => e.UserCode, "UQ__Users__1DF52D0CB8DE7374").IsUnique();

            entity.Property(e => e.AcademicHouse).HasMaxLength(100);
            entity.Property(e => e.Class).HasMaxLength(20);
            entity.Property(e => e.DivisionName).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.FourthName).HasMaxLength(100);
            entity.Property(e => e.FullName)
                .HasMaxLength(403)
                .HasComputedColumnSql("(ltrim(rtrim((((((isnull([FirstName],'')+' ')+isnull([SecondName],''))+' ')+isnull([ThirdName],''))+' ')+isnull([FourthName],''))))", true);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Languages).HasMaxLength(200);
            entity.Property(e => e.Mmid).HasColumnName("MMID");
            entity.Property(e => e.Nationalities).HasMaxLength(200);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.SecondName).HasMaxLength(100);
            entity.Property(e => e.ThirdName).HasMaxLength(100);
            entity.Property(e => e.Tutor).HasMaxLength(100);
            entity.Property(e => e.UserCode).HasMaxLength(50);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Mm).WithMany(p => p.Users)
                .HasForeignKey(d => d.Mmid)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Users_MediaFiles");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_Users_Parent");

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName("FK_Users_UserTypes");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
