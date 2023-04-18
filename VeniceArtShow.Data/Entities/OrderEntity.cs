using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        // [ForeignKey]
        // public int ProductId { get; set; }
        [Required]
        public int Price { get; set; }
        [ForeignKey]
        public int BuyerUserId { get; set; }
        [ForeignKey]
        public int SellerUserId { get; set; }
    }
