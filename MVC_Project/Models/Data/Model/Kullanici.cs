using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Project.Models.Data.Model
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Role { get; set; }
    }
}