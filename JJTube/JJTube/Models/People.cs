using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JJTube.Models
{
    [Table("People")]
    public class People
    {
        [Key]
        public int UserID { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<List> Lists { get; set; }
    }
}