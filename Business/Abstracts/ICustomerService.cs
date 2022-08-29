using Core.Utilities.Result;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(string companyName); 
        IResult Update(Customer customer); 
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetByCustomerId(int id);

    }
}
