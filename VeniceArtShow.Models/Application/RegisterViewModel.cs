using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// This is a file created from following kudvenkat, ASP NET Core Identity UserManager and SignInManager
// https://www.youtube.com/watch?v=TfarnVqnhX0
    public class RegisterViewModel
    {
        
    }

@model RegisterViewModel
ViewBag.Title = "User Registration"
<h1›User Registration‹/h1>
e‹div classe"row">
‹div class= col-md-12*> ‹form methods"post"›
‹div asp-validation-summaryla"All" classe"text-danger"›</div> ‹div classa"form-group">
‹label asp-fors"Email"›</label>
‹input asp-fors"Email" classa"form-control' /> <span asp-validation-fors"Email" class="text-danger*›</span›
</div> ‹div class="form-group">
‹label asp-fors"Password™></label>
‹input asp-for="Password" classe"form-control" /› ‹span asp-validation-fors "Password" classe"text-danger"›</span>
</div> ‹div class="form-group">