using System;
using System.Collections.Generic;

namespace DAL;

public partial class MediaFile
{
    public Guid Id { get; set; }

    public string? FileName { get; set; }

    public string? FileExtension { get; set; }

    public long? FileSize { get; set; }

    public string? FileType { get; set; }

    public byte[]? FileContent { get; set; }

    public DateTime? InsertDate { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
