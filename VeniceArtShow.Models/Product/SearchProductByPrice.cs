using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class SearchProductByPrice
{
    [Required]
    public string LowPrice { get; set; }
    [Required]
    public string HighPrice { get; set; }
}