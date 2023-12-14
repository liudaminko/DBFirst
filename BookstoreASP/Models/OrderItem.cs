using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookstoreASP.Models;

[PrimaryKey("ItemId", "OrderId")]
[Index("OrderId", Name = "IX_OrderItems_OrderId")]
public partial class OrderItem
{
    [Key]
    public int ItemId { get; set; }

    [Key]
    public int OrderId { get; set; }

    public int Amount { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("OrderItems")]
    public virtual Item Item { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderItems")]
    public virtual Order Order { get; set; } = null!;
}
