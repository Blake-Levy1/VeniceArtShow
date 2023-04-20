using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

public class UserEntity : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public DateTime DateCreated { get; set; }
    public string Biography { get; set; }

    // Following 14.03 under 'UserEntity'
    public virtual List<MediaEntity> Artworks { get; set; } = new List<MediaEntity>();
    public virtual  List<OrderEntity> Orders {get; set; } = new List<OrderEntity>();
}
