//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ahorasi.BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            this.VehiculosR = new HashSet<VehiculosR>();
        }
    
        public int Id_Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoUsuario { get; set; }
        public string Telefono { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehiculosR> VehiculosR { get; set; }
    }
}
