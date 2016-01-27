using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaVentas.Models
{
  [MetadataType(typeof(userMetadad))]
    public partial class Categoria
    {
      
    }

    public class userMetadad
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Descripcion { get; set; }

        
    }
}