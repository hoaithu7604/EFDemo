using CodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Interface
{
    public interface IBrandRepository
    {
        List<Brand> Get();
    }
}
