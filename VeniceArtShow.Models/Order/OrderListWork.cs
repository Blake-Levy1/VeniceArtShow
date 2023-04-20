using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
// This is a Model: What of an Entity is needed to act in Service & Controller
    // This is a Model
    //Created, modified w/ EN 17.01 in mind
    public class OrderListWork
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public  DateTimeOffset CreatedUtc { get; set; }
    }