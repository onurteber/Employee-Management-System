using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Project.Models.Data.Model
{
    public class Personel
    {
        
        public int PersonelID { get; set; }

        [Display(Name = "Personel Adı")]
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string PersonelAdi { get; set; }

        [Display(Name = "Personel Soyadı")]
        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        public string PersonelSoyadi { get; set; }

        [Display(Name = "Doğum Tarihi")]
        [Required(ErrorMessage = "Lütfen doğum tarihinizi seçiniz.")]
        public DateTime DogumTarih { get; set; }

        [Required(ErrorMessage ="Maaş alanı zorunludur.")]
        [Display(Name = "Maaş")]
        public int Maas { get; set; }

        [Required(ErrorMessage = "Lütfen cinsiyetinizi belirtiniz.")]
        public bool Cinsiyet { get; set; }

        [Display(Name = "Evlilik Durumu")]
        public bool EvliMi { get; set; }

        [Display(Name = "Departman Adı")]
        [Required(ErrorMessage ="Lütfen bir departman seçiniz.")]
        public int DepartmanID { get; set; }
        public virtual Departman Departman { get; set; }
    }
}