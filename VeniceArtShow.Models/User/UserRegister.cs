using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


public class UserRegister
{
    [Required]
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    [Required]
    public string PasswordHash { get; set; }
    [Required]
    [Compare("PasswordHash", ErrorMessage = "Password does not match")]
    public string ConfirmPassword { get; set; }
    [Required]
    public DateTime DateCreated { get; set; }
    public string Biography { get; set; }
}
