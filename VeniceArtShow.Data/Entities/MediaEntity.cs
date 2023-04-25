using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


public class MediaEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string MediaType { get; set; }
}
