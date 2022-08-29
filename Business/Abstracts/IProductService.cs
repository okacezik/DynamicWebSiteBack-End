using Core.Utilities.Result;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Delete(string productName);
        IResult Update(Product product);
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> GetByProductName(string ProductName);
    }
}
