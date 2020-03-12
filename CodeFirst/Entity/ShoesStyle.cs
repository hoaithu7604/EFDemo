using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entity
{
    public class ShoesStyle : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Shoes> Shoes { get; set; }
    }
}
