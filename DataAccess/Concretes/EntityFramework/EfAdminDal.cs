using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfAdminDal : EfEntityRepositoryBase<Admin, MyDatabaseContext>, IAdminDal
    {
        public bool LogIn(Expression<Func<Admin, bool>> filter)
        {
            using(MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = context.Set<Admin>().Where(filter).ToList();
                if(result.Count > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
