﻿using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Concretes.EntityFramework;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IAdminDal:IEntityRepository<Admin>
    {
        bool LogIn(Expression<Func<Admin , bool>> filter);
    }
}
