using CodeFirst.Entity;
using CodeFirst.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Repository
{
    public class BrandRepository : IBrandRepository
    {
        public List<Brand> Get()
        {
            try
            {
                using (var context = new CodeFirstContext())
                {
                    var result = context.Brands.Where(x => !x.isDeleted);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
