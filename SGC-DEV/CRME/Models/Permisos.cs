namespace CRME.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Permisos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_per { get; set; }

        public string descripcion { get; set; }

        public int Id_perfil { get; set; }

        public bool cre { get; set; }

        public bool rea { get; set; }

        public bool del { get; set; }

        public bool upd { get; set; }
    }
}