using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

public class OrderUpdate
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int BuyerId { get; set; }
    [Required]
    public string Price { get; set; }

}