using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ProductListItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string MediaType { get; set; }
    public string DateListed { get; set; }
    public bool IsSold { get; set; }
}