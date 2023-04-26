using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ProductDetail
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string ImageUrl { get; set; }
    public string MediaType { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string DateListed { get; set; }
    // public int MediaId { get; set; }
    // public MediaEntity Media { get; set; } 
    // would need access to MediaEntity to return Media Type
}