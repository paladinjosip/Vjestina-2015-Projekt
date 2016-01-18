using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JJTube.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        public string ItemLink { get; set; }

       // [ForeignKey("Lists")]
       // public int ListID { get; set; }
        public virtual List List { get; set; }
    }
}