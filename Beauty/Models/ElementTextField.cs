using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("ElementTextField")]
public partial class ElementTextField
{
    [Key]
    public int Id { get; set; }

    public int? TextFieldId { get; set; }

    public string? Value { get; set; }

    [ForeignKey("TextFieldId")]
    [InverseProperty("ElementTextFields")]
    public virtual TextField? TextField { get; set; }
}
