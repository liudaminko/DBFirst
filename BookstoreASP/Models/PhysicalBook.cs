using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookstoreASP.Models;

public partial class PhysicalBook
{
    [Key]
    public int ItemId { get; set; }

    public int CoverType { get; set; }

    public int Condition { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("PhysicalBook")]
    public virtual Item Item { get; set; } = null!;
}
