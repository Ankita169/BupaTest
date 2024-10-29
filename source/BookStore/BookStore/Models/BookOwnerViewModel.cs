using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStore.Model;

namespace BookStore.Models
{
    public class BookOwnerViewModel
    {
        public List<Owner> Adults { get; set; }
        public List<Owner> Children { get; set; }
    }
}