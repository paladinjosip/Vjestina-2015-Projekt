using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTube.Models
{
    public class Item_List_ViewModel
    {
        public Item_List_ViewModel() {
            List = new List();
        }

        public List List { get; set; }
        public Item ListItem { get; set; }
    }
}