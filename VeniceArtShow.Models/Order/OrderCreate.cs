using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
// This is a Model: What of an Entity is needed to act in Service & Controller
// Does one need a CS# file for every kind of data Model?
    public class OrderCreate
    {
        [Required]
        public int BuyerId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int ArtistId { get; set; }
        [Required]
        public double Price { get; set; }
        
    }