using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

// CONSIDER: changing 'user' to 'owner'
// Note in Version 1 is is assumed all users are owners. 
// In Version 2+ might distinguish between owners and makers
public class UserEntity : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required]
    public DateTime DateCreated { get; set; }
    public string Biography { get; set; }

    // Following 14.03 under 'UserEntity'
    // List containing all works
    // public virtual List<MediaEntity> Artworks { get; set; } = new List<MediaEntity>();
    // // List containing all orders
    // public virtual  List<OrderEntity> Orders {get; set; } = new List<OrderEntity>();
}
