using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CidicomPrototype.Models
{
    public class Activos
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IDActivos     { get; set; }
        [Required(ErrorMessage="por favor introduzca nombre del activo")]
        [DataType(DataType.Text)]
        public string nameActivos { get; set; }
        public int IDSitios { get; set; }

        public virtual ICollection<Servicios> Servicios { get; set; }

        public virtual Sitios Sitios { get; set; }
    }
}