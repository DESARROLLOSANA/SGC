//NUEVO

namespace CRME.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class cat_permisos_empresa
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cat_permisos_empresa()
        {
            cat_sistemas = new HashSet<cat_sistemas>();
        }

        // TABLA PARA ASIGNAR LOS PERMISOS NECESARIOS POR EMPRESA PARA CRUD
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int permisosE_ID { get; set; }
        // LLAVE FORANEA
        public int sistemas_ID { get; set; }
        // LLAVE FORANEA
        public int menu_ID { get; set; }

        public int lectura { get; set; }

        public int escritura { get; set; }

        public int eliminar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cat_sistemas> cat_sistemas { get; set; }

    }
}