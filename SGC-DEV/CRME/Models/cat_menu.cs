//NUEVO

namespace CRME.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class cat_menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cat_menu()
        {
            cat_sistemas = new HashSet<cat_sistemas>();
        }

        // TABLA PARA ASIGNAR LOS PERMISOS NECESARIOS POR USUARIO PARA CRUD
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int menu_ID { get; set; }
        // LLAVE
        public int menupadre_ID { get; set; }
        // POSICION DEL MENU
        public int pos_menu { get; set; }
        //MENU HABILITADO
        public int hab_menu { get; set; }
        //URL DEL MENU
        [StringLength(50)]
        public string Urlmenu { get; set; }
        //FORMULARIO ASOCIADO
        public int form_asoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cat_sistemas> cat_sistemas { get; set; }

    }
}