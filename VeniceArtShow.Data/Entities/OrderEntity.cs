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
    public readonly string Title;
    public readonly DateTimeOffset CreatedUtc;
    // private UserEntity fred;

    [ForeignKey(nameof(UserEntity))]
    public string BuyerId { get; set; }
    public UserEntity Buyer { get; set; }

    public DateTime PurchaseDate { get; set; }

    [ForeignKey(nameof(Media))]
    public int MediaId { get; set; }
    public virtual MediaEntity Media { get; set; }

    [ForeignKey(nameof(ProductEntity))]
    public int ProductId { get; set; }
    // public ProductEntity Artist { get; set; }
     public virtual ProductEntity Product { get; set; }

    [Required]
    public int Price { get; set; }
    // List containing all works
    public virtual List<MediaEntity> Artworks { get; set; } = new List<MediaEntity>();

    // List containing all users
    public virtual List<UserEntity> Owners { get; set; } = new List<UserEntity>();
}
