using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("TableWithTopicAndDescription")]
public partial class TableWithTopicAndDescription
{
    [Key]
    public int Id { get; set; }

    public string? Value1 { get; set; }

    public string? Value2 { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("TableWithTopicAndDescription")]
    public virtual Component IdNavigation { get; set; } = null!;
}
