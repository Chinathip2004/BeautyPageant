using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("TwoTableTopicImageCaptionButton")]
public partial class TwoTableTopicImageCaptionButton
{
    [Key]
    public int Id { get; set; }

    public string? Value1 { get; set; }

    public int? FileId1 { get; set; }

    public string? ButtonName1 { get; set; }

    public string? Url1 { get; set; }

    [Column("isUrl1")]
    public bool IsUrl1 { get; set; }

    public string? Value2 { get; set; }

    public int? FileId2 { get; set; }

    public string? Url2 { get; set; }

    public string? ButtonName2 { get; set; }

    [Column("isUrl2")]
    public bool IsUrl2 { get; set; }

    [ForeignKey("FileId1")]
    [InverseProperty("TwoTableTopicImageCaptionButtonFileId1Navigations")]
    public virtual FileImg? FileId1Navigation { get; set; }

    [ForeignKey("FileId2")]
    [InverseProperty("TwoTableTopicImageCaptionButtonFileId2Navigations")]
    public virtual FileImg? FileId2Navigation { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("TwoTableTopicImageCaptionButton")]
    public virtual Component IdNavigation { get; set; } = null!;
}
