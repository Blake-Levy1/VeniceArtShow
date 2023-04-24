using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
// This is a Model: What of an Entity is needed to act in Service & Controller
public class OrderUpdate
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int BuyerId { get; set; }

    [MinLength(2, ErrorMessage = "{0} must be at least {1} characters long.")]
    [MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
    public string Title { get; set; }

    [Required]
    public int Price { get; set; }

}