using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("Form")]
public partial class Form
{
    [Key]
    public int Id { get; set; }

    public string? Value { get; set; }

    public string? Url { get; set; }

    public string? ButtonName { get; set; }

    public int? FileIdPopup { get; set; }

    public string? ValuePopup { get; set; }

    [InverseProperty("Form")]
    public virtual ICollection<CopyForm> CopyForms { get; set; } = new List<CopyForm>();

    [InverseProperty("Form")]
    public virtual ICollection<FormComponent> FormComponents { get; set; } = new List<FormComponent>();

    [ForeignKey("Id")]
    [InverseProperty("Form")]
    public virtual Component IdNavigation { get; set; } = null!;
}
