using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedUtc { get; set; }
    [ForeignKey(nameof(Buyer))]
    public int BuyerId { get; set; }
    public UserEntity Buyer { get; set; }

    // [ForeignKey(nameof(Media))]
    // public int MediaId { get; set; }
    // public virtual MediaEntity Media { get; set; }

    [ForeignKey(nameof(ProductId))]
    public int ProductId { get; set; }
    public virtual ProductEntity Product { get; set; }

    [ForeignKey(nameof(Artist))] 
    public int ArtistId { get; set; }
    public virtual UserEntity Artist { get; set; }
    [Required]
    public double Price { get; set; }

    // List containing all works
    // Perhaps not needed
    // public virtual List<MediaEntity> Artworks { get; set; } = new List<MediaEntity>();

    // // List containing all users
    // public virtual List<UserEntity> Owners { get; set; } = new List<UserEntity>();
}
