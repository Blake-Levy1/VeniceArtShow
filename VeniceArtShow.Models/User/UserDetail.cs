using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UserDetail
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Biography { get; set; }
    public DateTimeOffset DateCreated { get; set; }
}