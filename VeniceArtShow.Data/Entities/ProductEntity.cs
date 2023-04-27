using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public class ProductEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    [Required]
    public string Description { get; set; }
    [ForeignKey(nameof(Artist))]
    public int ArtistId { get; set; }
    public virtual UserEntity Artist { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public DateTime DateListed { get; set; }
    [ForeignKey(nameof(Media))]
    public int MediaId { get; set; }
    public virtual MediaEntity Media { get; set; }
    public bool IsSold { get; set; }
}