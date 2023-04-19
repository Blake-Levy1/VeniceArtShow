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
    public Guid ArtistId { get; set; }
    public UserEntity Artist { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public DateTimeOffset DateListed { get; set; }
    [ForeignKey(nameof(Media))]
    public int MediaId { get; set; }
    public MediaEntity Media { get; set; }
}