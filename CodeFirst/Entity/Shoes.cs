using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entity
{
    public class Shoes : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<ShoesStyle> Styles { get; set; }
    }
}
