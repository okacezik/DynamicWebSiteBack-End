using Core.DataAccess;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    //bu class interface'e entity nesnesini <> icerisine verir
    public interface IProductDal:IEntityRepository<Product>
    {

    }
}
