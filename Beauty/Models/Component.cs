using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("Component")]
public partial class Component
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual About? About { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Banner? Banner { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Button? Button { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Container? Container { get; set; }

    [InverseProperty("Component")]
    public virtual ICollection<Containing> Containings { get; set; } = new List<Containing>();

    [InverseProperty("IdNavigation")]
    public virtual Form? Form { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual GridFourImage? GridFourImage { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual GridTwoColumn? GridTwoColumn { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ImageDescription? ImageDescription { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ImageWithCaption? ImageWithCaption { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual OneTopicImageCaptionButton? OneTopicImageCaptionButton { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual Sale? Sale { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual TableWithTopicAndDescription? TableWithTopicAndDescription { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual TextBox? TextBox { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual TwoTableTopicImageCaptionButton? TwoTableTopicImageCaptionButton { get; set; }
}
