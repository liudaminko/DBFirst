using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookstoreASP.Models;

[Index("DeliveryTypeId", Name = "IX_Deliveries_DeliveryTypeId")]
public partial class Delivery
{
    [Key]
    public int Id { get; set; }

    public int DeliveryTypeId { get; set; }

    public string? Address { get; set; }

    public string TrackingNumber { get; set; } = null!;

    [ForeignKey("DeliveryTypeId")]
    [InverseProperty("Deliveries")]
    public virtual DeliveryType DeliveryType { get; set; } = null!;

    [InverseProperty("Delivery")]
    public virtual Order? Order { get; set; }
}
