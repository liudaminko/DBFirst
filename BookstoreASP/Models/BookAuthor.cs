using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookstoreASP.Models;

[Keyless]
[Index("AuthorId", Name = "IX_BookAuthors_AuthorId")]
[Index("ItemId", Name = "IX_BookAuthors_ItemId")]
public partial class BookAuthor
{
    public int ItemId { get; set; }

    public int AuthorId { get; set; }

    [ForeignKey("AuthorId")]
    public virtual Author Author { get; set; } = null!;

    [ForeignKey("ItemId")]
    public virtual Item Item { get; set; } = null!;
}
