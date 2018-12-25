using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Project.Models.Data.Model
{
    public class Departman
    {
        public int DepartmanID { get; set; }

        [Display(Name = "Departman Adı")]

        [Required(ErrorMessage ="Bu alan zorunludur.")]
        public string Ad { get; set; }
    }
}