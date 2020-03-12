using DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst.Interface
{
    public interface IShoesStyleRepository
    {
        List<ShoesStyle> Get();
    }
}
