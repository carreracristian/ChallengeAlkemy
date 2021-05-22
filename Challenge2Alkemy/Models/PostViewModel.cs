using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Challenge2Alkemy.Models
{
    public class PostViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El titulo es obligatorio")]
        [StringLength(50,ErrorMessage ="El {0} debe ser almenos {2} y maximo {1} caracteres",MinimumLength =3)]
        [Display(Name ="Titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El Contenido es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser almenos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Contenido")]
        public string Contenido { get; set; }


        [Display(Name = "Imagen")]
        public byte[] Imagen { get; set; }
        //public HttpPostedFileBase Imagen { get; set; }

        [Required(ErrorMessage = "La Categoria es obligatoria")]
        [StringLength(50, ErrorMessage = "El {0} debe ser almenos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Posteo")]
        public DateTime FechaDeCreacion { get; set; }
        public bool EstaBorrado { get; set; }
    }
}
