using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

public class ProductUpdate
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MinLength(3, ErrorMessage = "{0} must be at lest {1} characters long.")]
    [MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
    public string Title { get; set; }
    [Required]
    [Url]
    public string ImageUrl { get; set; }
    [Required]
    [MaxLength(8000, ErrorMessage = "{0} must contain no more than {1} characters.")]
    public string Description { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public int ArtistId { get; set; }
    [Required]
    public int MediaId { get; set; }
    public bool IsSold { get; set; }
}