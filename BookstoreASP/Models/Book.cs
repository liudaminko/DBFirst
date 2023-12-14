using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookstoreASP.Models;

[Index("GenreId", Name = "IX_Books_GenreId")]
[Index("PublisherId", Name = "IX_Books_PublisherId")]
[Index("TranslatorId", Name = "IX_Books_TranslatorId")]
public partial class Book
{
    [Key]
    public int ItemId { get; set; }

    public int GenreId { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal Rating { get; set; }

    public int PublicationYear { get; set; }

    public int PublisherId { get; set; }

    public int? TranslatorId { get; set; }

    public string Language { get; set; } = null!;

    public int Pages { get; set; }

    [ForeignKey("GenreId")]
    [InverseProperty("Books")]
    public virtual Genre Genre { get; set; } = null!;

    [ForeignKey("PublisherId")]
    [InverseProperty("Books")]
    public virtual Publisher Publisher { get; set; } = null!;

    [ForeignKey("TranslatorId")]
    [InverseProperty("Books")]
    public virtual Translator? Translator { get; set; }
}
