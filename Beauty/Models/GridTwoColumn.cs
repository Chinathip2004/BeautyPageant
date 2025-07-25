using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("GridTwoColumn")]
public partial class GridTwoColumn
{
    [Key]
    public int Id { get; set; }

    public int? FileIdLeft { get; set; }

    public string? ValueLeft { get; set; }

    public int? FileIdRight { get; set; }

    public string? ValueRight { get; set; }

    public string? UrlLeft { get; set; }

    public string? UrlRight { get; set; }

    [ForeignKey("FileIdLeft")]
    [InverseProperty("GridTwoColumnFileIdLeftNavigations")]
    public virtual FileImg? FileIdLeftNavigation { get; set; }

    [ForeignKey("FileIdRight")]
    [InverseProperty("GridTwoColumnFileIdRightNavigations")]
    public virtual FileImg? FileIdRightNavigation { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("GridTwoColumn")]
    public virtual Component IdNavigation { get; set; } = null!;
}
