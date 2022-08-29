using Core.DataAccess;
using Entities.Concretes;
using Entities.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IOrderDal:IEntityRepository<Order>
    {
        List<OrderDetailsDto> GetOrderDetails(Expression<Func<OrderDetailsDto , bool>> filter = null);
    }
}
