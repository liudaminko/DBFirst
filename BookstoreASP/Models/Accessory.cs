using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookstoreASP.Models;

public partial class Accessory
{
    [Key]
    public int ItemId { get; set; }

    public string? Material { get; set; }

    public string? Coating { get; set; }

    public int? Weight { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("Accessory")]
    public virtual Item Item { get; set; } = null!;
}
