using Business.Abstracts;
using Business.Constant;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class CustomerManager : ICustomerService
    {

        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(string companyName)
        {
            if(DeleteControl(companyName) != null)
            {
                _customerDal.Delete(DeleteControl(companyName));
                return new SuccessResult(Messages.CustomerDeleted);
            }
            return new ErrorResult("müşteri silme işlemi başarısız...");
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
        }

        public IDataResult<Customer> GetByCustomerId(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.CustomerId == id), Messages.CustomerListed);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public Customer DeleteControl(string companyName)
        {
            Customer customer = _customerDal.Get(c => c.CompanyName == companyName);
            return customer;
        }
    }
}
