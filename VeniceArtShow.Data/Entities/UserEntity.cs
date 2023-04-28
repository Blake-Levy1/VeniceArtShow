using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


// CONSIDER: changing 'user' to 'owner'
// Note in Version 1 MVP it is assumed all users are owners; orders created by buyers. 
// In Version 2+ might distinguish between owners, makers, artists, art-lovers and add admin.
public class UserEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Biography { get; set; }
    [Required]
    public DateTime DateCreated { get; set; }

    // Set up following 14.03 under 'UserEntity'; discontinued.
    // The following instatiates a list containing all Media
    // public virtual List<MediaEntity> Artworks { get; set; } = new List<MediaEntity>();
    // The following instatiates a lits containing all Orders
    // public virtual  List<OrderEntity> Orders {get; set; } = new List<OrderEntity>();
}
