using Core.Utilities.Result;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IAdminService
    {
        IDataResult<List<Admin>> GetAll();
        IResult LogIn(string userName , string password);
        IResult Add(Admin admin);
        IResult Delete(string adminName);
    }
}
