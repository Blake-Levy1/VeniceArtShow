using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

public class GetOrdersByArtistId
    {

    [Required] 
    public int ArtistId { get; set; }  
    [Required]
    public int BuyerId { get; set; }
    }