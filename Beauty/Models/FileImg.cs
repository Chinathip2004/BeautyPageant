using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("FileImg")]
public partial class FileImg
{
    [Key]
    public int Id { get; set; }

    public string? FileName { get; set; }

    public string? FilePath { get; set; }

    [InverseProperty("FileId1Navigation")]
    public virtual ICollection<About> AboutFileId1Navigations { get; set; } = new List<About>();

    [InverseProperty("FileIdLeftNavigation")]
    public virtual ICollection<About> AboutFileIdLeftNavigations { get; set; } = new List<About>();

    [InverseProperty("FileIdRightNavigation")]
    public virtual ICollection<About> AboutFileIdRightNavigations { get; set; } = new List<About>();

    [InverseProperty("File")]
    public virtual ICollection<Banner> Banners { get; set; } = new List<Banner>();

    [InverseProperty("File")]
    public virtual ICollection<ElementImageUploadWithImageContent> ElementImageUploadWithImageContents { get; set; } = new List<ElementImageUploadWithImageContent>();

    [InverseProperty("File")]
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    [InverseProperty("FileId1Navigation")]
    public virtual ICollection<GridFourImage> GridFourImageFileId1Navigations { get; set; } = new List<GridFourImage>();

    [InverseProperty("FileId2Navigation")]
    public virtual ICollection<GridFourImage> GridFourImageFileId2Navigations { get; set; } = new List<GridFourImage>();

    [InverseProperty("FileId3Navigation")]
    public virtual ICollection<GridFourImage> GridFourImageFileId3Navigations { get; set; } = new List<GridFourImage>();

    [InverseProperty("FileId4Navigation")]
    public virtual ICollection<GridFourImage> GridFourImageFileId4Navigations { get; set; } = new List<GridFourImage>();

    [InverseProperty("FileIdLeftNavigation")]
    public virtual ICollection<GridTwoColumn> GridTwoColumnFileIdLeftNavigations { get; set; } = new List<GridTwoColumn>();

    [InverseProperty("FileIdRightNavigation")]
    public virtual ICollection<GridTwoColumn> GridTwoColumnFileIdRightNavigations { get; set; } = new List<GridTwoColumn>();

    [InverseProperty("File")]
    public virtual ICollection<ImageDescription> ImageDescriptions { get; set; } = new List<ImageDescription>();

    [InverseProperty("File")]
    public virtual ICollection<ImageWithCaption> ImageWithCaptions { get; set; } = new List<ImageWithCaption>();

    [InverseProperty("File")]
    public virtual ICollection<OneTopicImageCaptionButton> OneTopicImageCaptionButtons { get; set; } = new List<OneTopicImageCaptionButton>();

    [InverseProperty("FileId1Navigation")]
    public virtual ICollection<Sale> SaleFileId1Navigations { get; set; } = new List<Sale>();

    [InverseProperty("FileId2Navigation")]
    public virtual ICollection<Sale> SaleFileId2Navigations { get; set; } = new List<Sale>();

    [InverseProperty("FileId1Navigation")]
    public virtual ICollection<TwoTableTopicImageCaptionButton> TwoTableTopicImageCaptionButtonFileId1Navigations { get; set; } = new List<TwoTableTopicImageCaptionButton>();

    [InverseProperty("FileId2Navigation")]
    public virtual ICollection<TwoTableTopicImageCaptionButton> TwoTableTopicImageCaptionButtonFileId2Navigations { get; set; } = new List<TwoTableTopicImageCaptionButton>();
}
