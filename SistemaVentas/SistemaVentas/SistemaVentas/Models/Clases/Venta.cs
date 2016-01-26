using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaVentas.Models
{
    public  partial class Venta
    {
        public virtual ICollection<Producto> Producto { get; set; }
    }
}