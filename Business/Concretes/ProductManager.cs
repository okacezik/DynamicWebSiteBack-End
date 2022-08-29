using Business.Abstracts;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Result;
using DataAccess.Abstracts;
using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //var context = new ValidationContext<Product>(product);
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(context);
            //if (result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(string productName)
        {
            
            if(DeleteControl(productName) != null)
            {
                _productDal.Delete(DeleteControl(productName));
                return new SuccessResult(Messages.ProductDeleted);
            }
            return new ErrorResult(Messages.ProductDidNotDelete);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<Product> GetByProductName(string ProductName)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductName == ProductName),Messages.ProductListed);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdate);
        }

        public Product DeleteControl(string productName)
        {
            Product product = _productDal.Get(p => p.ProductName == productName);
            return product;
        }
    }
}
