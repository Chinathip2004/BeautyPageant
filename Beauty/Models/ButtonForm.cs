using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("ButtonForm")]
public partial class ButtonForm
{
    [Key]
    public int Id { get; set; }

    public string? Value { get; set; }

    public string? Url { get; set; }

    public bool IsUrl { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ButtonForm")]
    public virtual FormComponent IdNavigation { get; set; } = null!;
}
