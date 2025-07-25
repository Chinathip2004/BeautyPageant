using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("GridFourImage")]
public partial class GridFourImage
{
    [Key]
    public int Id { get; set; }

    public int? FileId1 { get; set; }

    public int? FileId2 { get; set; }

    public int? FileId3 { get; set; }

    public int? FileId4 { get; set; }

    [ForeignKey("FileId1")]
    [InverseProperty("GridFourImageFileId1Navigations")]
    public virtual FileImg? FileId1Navigation { get; set; }

    [ForeignKey("FileId2")]
    [InverseProperty("GridFourImageFileId2Navigations")]
    public virtual FileImg? FileId2Navigation { get; set; }

    [ForeignKey("FileId3")]
    [InverseProperty("GridFourImageFileId3Navigations")]
    public virtual FileImg? FileId3Navigation { get; set; }

    [ForeignKey("FileId4")]
    [InverseProperty("GridFourImageFileId4Navigations")]
    public virtual FileImg? FileId4Navigation { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("GridFourImage")]
    public virtual Component IdNavigation { get; set; } = null!;
}
