using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookstoreASP.Models;

[Table("EBooks")]
public partial class Ebook
{
    [Key]
    public int ItemId { get; set; }

    public string MediaType { get; set; } = null!;

    public int FileSize { get; set; }

    public string DownloadLink { get; set; } = null!;

    [ForeignKey("ItemId")]
    [InverseProperty("Ebook")]
    public virtual Item Item { get; set; } = null!;
}
