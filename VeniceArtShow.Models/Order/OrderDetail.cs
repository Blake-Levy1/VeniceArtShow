using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
// This is a Model: What of an Entity is needed to act in Service & Controller
    public class OrderDetail
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public int ArtistId { get; set; }
        public double Price { get; set; }
        // public int MediaId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

    }
