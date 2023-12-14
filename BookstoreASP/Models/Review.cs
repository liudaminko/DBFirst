using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookstoreASP.Models;

[PrimaryKey("UserId", "ItemId")]
public partial class Review
{
    [Key]
    public int ItemId { get; set; }

    [Key]
    public int UserId { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal Rating { get; set; }

    public string? Comment { get; set; }
}
