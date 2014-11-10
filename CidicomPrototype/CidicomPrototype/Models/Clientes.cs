using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CidicomPrototype.Models
{
    public class Clientes
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IDCliente { get; set; }

        [Required(ErrorMessage="por favor introduzca nombre")]
        [DataType(DataType.Text)]
        public string NameCliente { get; set; }

        public virtual ICollection<Sitios> Sitios { get; set; }
    }
}