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

    [ForeignKey(nameof(UserEntity))]
    public int BuyerId { get; set; }
    public UserEntity Buyer { get; set; }
    public DateTime PurchaseDate { get; set; }

    [ForeignKey(nameof(Media))]
    public int MediaId { get; set; }
    public virtual MediaEntity Media { get; set; }

    [ForeignKey(nameof(UserEntity))]
    public Guid ArtistId { get; set; }
    public virtual UserEntity Artist { get; set; }

    [Required]
    public int Price { get; set; }
}
