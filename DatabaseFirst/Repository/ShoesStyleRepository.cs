using DatabaseFirst.Interface;
using DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst.Repository
{
    public class ShoesStyleRepository : IShoesStyleRepository
    {
        public List<ShoesStyle> Get()
        {
            try
            {
                using(var context=new ShoesEntities())
                {
                    var result = context.ShoesStyles.Where(x => !x.isDeleted);
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
