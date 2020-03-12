using CodeFirst.Entity;
using CodeFirst.Filter;
using CodeFirst.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace CodeFirst.Repository
{
    public class ShoesRepository : IShoesRepository
    {
        public int Delete(Shoes shoes)
        {
            return Delete(shoes.Id);
        }

        public int Delete(Guid id)
        {
            try
            {
                using (CodeFirstContext context = new CodeFirstContext())
                {
                    var entity = context.Shoes.FirstOrDefault(x => x.Id == id);
                    if (entity == null) throw new Exception();
                    else
                    {
                        entity.isDeleted = true;
                        context.SaveChanges();
                        return 1;
                    }

                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public List<Shoes> Get(ShoesFilter filter)
        {
            try
            {
                using(CodeFirstContext context = new CodeFirstContext())
                {
                    var result = context.Shoes.Include(s=>s.Styles).Include(s=>s.Brand).Where(x=>!x.isDeleted);

                    if (filter != null)
                    {
                        if (filter.Id != Guid.Empty)
                        {
                            result = result.Where(x => x.Id == filter.Id);
                        }

                        if (filter.Name != string.Empty)
                        {
                            result = result.Where(x => x.Name.Contains(filter.Name));
                        }

                        if (filter.Brand_Ids != null)
                        {
                            result = result.Where(x => filter.Brand_Ids.Contains(x.Brand.Id));
                        }

                        if (filter.Style_Ids != null)
                        {
                            result = result.Where(x => x.Styles.Any(style => filter.Style_Ids.Contains(style.Id)));
                        }
                    }

                    return result.ToList();
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Shoes InsertOrUpdate(Shoes shoes)
        {
            try
            {
                using(var context = new CodeFirstContext())
                {
                    var result = context.Shoes.FirstOrDefault(x => x.Id == shoes.Id);
                    if (result == null)
                    {
                        shoes.Id = Guid.NewGuid();
                        shoes.Styles = shoes.Styles.Select(x => context.ShoesStyles.Find(x.Id)).ToList();
                        shoes.Brand = context.Brands.Find(shoes.Brand.Id);
                        shoes.CreatedDate = DateTime.Now;
                        result = context.Shoes.Add(shoes);
                    }
                    else
                    {
                        result.Styles.Clear();
                        var styles = shoes.Styles.Select(x => context.ShoesStyles.Find(x.Id)).ToList();
                        foreach (var style in styles)
                        {
                            result.Styles.Add(style);
                        }
                        result.Brand = context.Brands.Find(shoes.Brand.Id);
                        result.ModifiedDate = DateTime.Now;
                    }
                    context.SaveChanges();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
