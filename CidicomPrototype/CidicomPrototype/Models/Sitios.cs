using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CidicomPrototype.Models
{
    public class Sitios
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IDSitios { get; set; }

        [Required(ErrorMessage = "por favor introduzca nombre")]
        [DataType(DataType.Text)]
        public string nameSitios { get; set; }
        public int IDCliente { get; set; }

        public virtual ICollection<Activos> Activos { get; set; }

        public virtual Clientes Clientes { get; set; }
    }
}