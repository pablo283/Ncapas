//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sucursal
    {
        public Sucursal()
        {
            this.ProductoSucursals = new HashSet<ProductoSucursal>();
        }
    
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<ProductoSucursal> ProductoSucursals { get; set; }
    }
}
