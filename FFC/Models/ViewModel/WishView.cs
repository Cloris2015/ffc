using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel;
using System.ComponentModel.DataAnnotations;

namespace FFC.Models.ViewModel
{
    public class WishView
    {
        public Wish Wish { get; set; }
        [Display(Name="User Name")]
        public String UserName { get; set; }
        public WishView()
        {
            this.Wish = new Wish();
        }
    }
}