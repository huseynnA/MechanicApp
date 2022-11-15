using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entites
{
    public class Personal:BaseEntity
    {
        [Required]
        public string Name{ get; set; }
        public string Surname{ get; set; }
        [Required]
        public string Duty{ get; set; }
        public string Email{ get; set; }
        [Required]
        public string Phone{ get; set; }
    }
}
