using Sigortam.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sigortam.Entities.Model
{
    public class User : IEntity
    {
        [Key]
        public int InUserId { get; set; }
        [Required(ErrorMessage = "Plaka alanı zorunlu")]
        public string StPlaka { get; set; }
        [Required(ErrorMessage = "TCKN alanı zorunlu")]
        public string StTCKN { get; set; }
        [Required(ErrorMessage = "Ruhsat Seri Kodu alanı zorunlu")]
        public string StRuhsatSeriKodu { get; set; }
        [Required(ErrorMessage = "Ruhsat Seri No alanı zorunlu")]
        public string StRuhsatSeriNo { get; set; }

    }
}
