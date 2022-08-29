using Business.Abstracts;
using Business.Constant;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class OrderManager : IOrderService
    {

        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(int orderProductId, int customerId)
        {
            if(DeleteControl(orderProductId , customerId) != null)
            {
                _orderDal.Delete(DeleteControl(orderProductId, customerId));
                return new SuccessResult(Messages.OrderDeleted);
            }
            return new ErrorResult("böyle bir sipariş bulunamadı...");
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.OrderListed);
        }

        public IDataResult<List<Order>> GetAllByCustomerId(int CustomerId)
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o => o.CustomerId == CustomerId),Messages.OrderListed);
        }

        public IDataResult<List<OrderDetailsDto>> GetOrderDetails()
        {
            return new SuccessDataResult<List<OrderDetailsDto>>(_orderDal.GetOrderDetails(), Messages.OrderListed);
        }

        public IDataResult<List<OrderDetailsDto>> GetOrderDetailsByCompanyName(string companyName)
        {
            return new SuccessDataResult<List<OrderDetailsDto>>(_orderDal.GetOrderDetails(o => o.CompanyName == companyName) , Messages.OrdersListed);
        }

        public IResult Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessResult(Messages.OrderUpdated);
        }

        public Order DeleteControl( int orderProductId , int customerId)
        {
            Order order = _orderDal.Get(o=> o.OrderProductId == orderProductId & o.CustomerId == customerId);
            return order;
        }
    }
}
