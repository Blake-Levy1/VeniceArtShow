using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


public class UserRegister
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [Required]
    public string PasswordHash{ get; set; }
    [Compare("PasswordHash", ErrorMessage = "Password does not match. Are you an having a bad typing day?")]
    public string ConfirmPassword { get; set; }
    [Required]
    public DateTime DateCreated { get; set; }
    public string Biography { get; set; }
}
