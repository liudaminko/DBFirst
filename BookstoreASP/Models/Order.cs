using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookstoreASP.Models;

[Index("DeliveryId", Name = "IX_Orders_DeliveryId", IsUnique = true)]
public partial class Order
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int DeliveryId { get; set; }

    public DateTime OrderDate { get; set; }

    [ForeignKey("DeliveryId")]
    [InverseProperty("Order")]
    public virtual Delivery Delivery { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
