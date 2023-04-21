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
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password{ get; set; }
    [Compare("Password", ErrorMessage = "Password does not match. Are you an having a bad typing day?")]
    public string ConfirmPassword { get; set; }
    public string Biography { get; set; }
}
