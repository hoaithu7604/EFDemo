using DatabaseFirst.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst.Interface
{
    public interface IShoesRepository
    {
        Shoes InsertOrUpdate(Shoes shoes);
        int Delete(Shoes shoes);
        int Delete(Guid id);
        List<Shoes> Get(ShoesFilter filter=null);
    }
}
