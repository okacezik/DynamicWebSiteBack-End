using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Concretes.DTOs;
using System.Linq.Expressions;


namespace DataAccess.Concretes.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, MyDatabaseContext>, IOrderDal
    {
        public List<OrderDetailsDto> GetOrderDetails(Expression<Func<OrderDetailsDto, bool>> filter = null)
        {
            using(MyDatabaseContext context = new MyDatabaseContext())
            {
                var result = from o in context.Orders
                             join c in context.Customers
                             on o.CustomerId equals c.CustomerId
                             join p in context.Products
                             on o.OrderProductId equals p.ProductId
                             select new OrderDetailsDto
                             {
                                 OrderId = o.OrderId,
                                 ProductName = p.ProductName,
                                 CompanyName = c.CompanyName,
                                 OrderDate = o.OrderDate,
                                 IsDelivered = o.IsDelivered
                             };

                if(filter == null)
                {
                    return result.ToList();
                }
                return result.Where(filter).ToList();
            }
        }
    }
}
