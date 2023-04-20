using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

    public class OrderCreate
    {
        [Required]
        [MinLength(2, ErrorMessage ="{0} must be at least {1} characters long.")]
        [MaxLength(100,ErrorMessage="{0} must contain no more than {1} characters.")]
        public string Title { get; set; }

        [Required]
        public int Price { get; set; }
        [Required]
        public int BuyerId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }