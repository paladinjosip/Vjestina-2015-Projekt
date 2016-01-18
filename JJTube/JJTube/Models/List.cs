using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JJTube.Models
{
    [Table("Lists")]
    public class List
    {
        [Key]
        public int ListID { get; set; }

     // [ForeignKey("People")]
     // public int UserID { get; set; }
  
        public string ListName { get; set; }

        public virtual People User { get; set; }
        public virtual ICollection<Item> Items { get; set; }

    }
}