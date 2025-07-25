using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("About")]
public partial class About
{
    [Key]
    public int Id { get; set; }

    public int? FileId1 { get; set; }

    public string? Value1 { get; set; }

    public string? Value2 { get; set; }

    public int? FileIdLeft { get; set; }

    public string? ValueLeft { get; set; }

    public int? FileIdRight { get; set; }

    public string? ValueRight { get; set; }

    public string? UrlLeft { get; set; }

    public string? UrlRight { get; set; }

    [ForeignKey("FileId1")]
    [InverseProperty("AboutFileId1Navigations")]
    public virtual FileImg? FileId1Navigation { get; set; }

    [ForeignKey("FileIdLeft")]
    [InverseProperty("AboutFileIdLeftNavigations")]
    public virtual FileImg? FileIdLeftNavigation { get; set; }

    [ForeignKey("FileIdRight")]
    [InverseProperty("AboutFileIdRightNavigations")]
    public virtual FileImg? FileIdRightNavigation { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("About")]
    public virtual Component IdNavigation { get; set; } = null!;
}
