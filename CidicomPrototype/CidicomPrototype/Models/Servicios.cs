using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CidicomPrototype.Models
{
    public class Servicios
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IDServicios { get; set; }
        [Required(ErrorMessage = "por favor introduzca nombre")]
        [DataType(DataType.Text)]
        public string nameServicios { get; set; }
        public int IDActivos { get; set; }

        public virtual ICollection<Tareas> Tareas { get; set; }

        public virtual Activos Activos { get; set; }
    }
}