using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("Event")]
public partial class Event
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? FileId { get; set; }

    public bool IsFavorite { get; set; }

    [InverseProperty("Event")]
    public virtual ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();

    [InverseProperty("Event")]
    public virtual ICollection<EventCategorize> EventCategorizes { get; set; } = new List<EventCategorize>();

    [ForeignKey("FileId")]
    [InverseProperty("Events")]
    public virtual FileImg? File { get; set; }
}
