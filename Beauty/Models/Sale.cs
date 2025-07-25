using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("Sale")]
public partial class Sale
{
    [Key]
    public int Id { get; set; }

    public string? Value1 { get; set; }

    public string? Value2 { get; set; }

    public double? PromotionPrice { get; set; }

    public double? Normal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    public string? Value3 { get; set; }

    public string? ButtonName { get; set; }

    [Column("isUrl")]
    public bool IsUrl { get; set; }

    public string? Value4 { get; set; }

    public int? FileId1 { get; set; }

    public string? NameLeft { get; set; }

    public string? UrlLeft { get; set; }

    public int? FileId2 { get; set; }

    public string? UrlRight { get; set; }

    public string? NameRight { get; set; }

    public string? UrlButton { get; set; }

    [ForeignKey("FileId1")]
    [InverseProperty("SaleFileId1Navigations")]
    public virtual FileImg? FileId1Navigation { get; set; }

    [ForeignKey("FileId2")]
    [InverseProperty("SaleFileId2Navigations")]
    public virtual FileImg? FileId2Navigation { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Sale")]
    public virtual Component IdNavigation { get; set; } = null!;
}
