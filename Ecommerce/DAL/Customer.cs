using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("tb_customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string Picture { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
