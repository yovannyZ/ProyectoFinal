//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaVentasPrueba
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoComprobante
    {
        public TipoComprobante()
        {
            this.Venta = new HashSet<Venta>();
        }
    
        public int IdTipoComprobante { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
