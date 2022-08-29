using Core.Utilities.Result;
using Entities.Concretes;
using Entities.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IOrderService
    {
        IResult  Add(Order order);  //sipariş verilirken ürün var mı kontrol et
        IResult Delete(int orderProductId,int customerId);
        IResult Update(Order order);
        IDataResult<List<Order>> GetAll();
        IDataResult<List<Order>> GetAllByCustomerId(int CustomerId);
        IDataResult<List<OrderDetailsDto>> GetOrderDetails();
        IDataResult<List<OrderDetailsDto>> GetOrderDetailsByCompanyName(string companyName);
    }
}
