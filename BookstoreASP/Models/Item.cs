using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookstoreASP.Models;

public partial class Item
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Column(TypeName = "decimal(6, 2)")]
    public decimal Price { get; set; }

    [InverseProperty("Item")]
    public virtual Accessory? Accessory { get; set; }

    [InverseProperty("Item")]
    public virtual Ebook? Ebook { get; set; }

    [InverseProperty("Item")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Item")]
    public virtual PhysicalBook? PhysicalBook { get; set; }
}
