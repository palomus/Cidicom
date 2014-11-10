using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CidicomPrototype.Models
{
    public enum Estado
    {
        Proceso, Finalizado, Cancelado
    }

    public class Tareas
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IDTareas { get; set; }
        [Required(ErrorMessage = "por favor introduzca nombre")]
        [DataType(DataType.Text)]
        public string nameTareas { get; set; }
        public int IDTecnico { get; set; }
        public int IDServicios { get; set; }
        [Required]
        public Estado? Estado { get; set; }
        

        public virtual Servicios Servicios { get; set; }
        public virtual Tecnico Tecnico { get; set; }
    }
}