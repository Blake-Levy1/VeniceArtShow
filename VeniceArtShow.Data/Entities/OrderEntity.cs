using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderEntity
{
    public readonly string Title;
    public readonly DateTimeOffset CreatedUtc;

    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(UserEntity))]
    public string BuyerId { get; set; }
    public UserEntity Buyer { get; set; }
    public DateTime PurchaseDate { get; set; }

    [ForeignKey(nameof(Media))]
    public int MediaId { get; set; }
    public virtual MediaEntity Media { get; set; }

    [ForeignKey(nameof(UserEntity))]
    public string ArtistId { get; set; }
    public virtual UserEntity Artist { get; set; }

    [Required]
    public int Price { get; set; }
}
