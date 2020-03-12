using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst.Filter
{
    public class ShoesFilter
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public List<Guid> Brand_Ids { get; set; } = null;
        public List<Guid> Style_Ids { get; set; } = null;

    }
}
