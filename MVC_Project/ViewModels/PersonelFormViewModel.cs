using MVC_Project.Models.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Project.ViewModels
{
    public class PersonelFormViewModel
    {
        public IEnumerable<Departman> Departmanlar { get; set; }

        public Personel Personeller { get; set; }
    }
    
}