using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CidicomPrototype.Models
{
    public class Tecnico
    {  
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IDTecnico { get; set; }
        [Required(ErrorMessage = "por favor introduzca nombre")]
        [DataType(DataType.Text)]
        public string NameTecnico { get; set; }

        public virtual ICollection<Tareas> Tareas { get; set; }
    }
}


