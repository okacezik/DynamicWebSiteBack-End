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
    public class AdminManager : IAdminService
    {

        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public IResult Add(Admin admin)
        {
            _adminDal.Add(admin);
            return new SuccessResult("admin eklendi");
        }

        public IResult Delete(string adminName)
        {
            //var result = DeleteControl(admin);
            //if (result)
            //{
            //    _adminDal.Delete(admin);
            //    return new SuccessResult(Messages.AdminDeleted);
            //}
            //return new ErrorResult("admin silme işlemi başarısız...");

            Admin admin = DeleteControl(adminName);
            if(admin != null)
            {
                _adminDal.Delete(admin);
                return new SuccessResult(Messages.AdminDeleted);
            }
            return new ErrorResult("admin silme işlemi başarısız...");
        }

        public IDataResult<List<Admin>> GetAll()
        {
            return new SuccessDataResult<List<Admin>>(_adminDal.GetAll(), Messages.AdminsListed);
        }

        public IDataResult<Admin> Get(string userName , string password)
        {
            return new SuccessDataResult<Admin>(_adminDal.Get(a => a.UserName == userName & a.Password == password));
        }

        public IResult LogIn(string userName , string password)
        {
            var result = _adminDal.LogIn(a=>a.UserName == userName & a.Password == password);
            if (result)
            {
                return new SuccessResult("giriş yapabilir...");
            }
            return new ErrorResult("giriş yapamaz...");
        }

        public Admin DeleteControl(string adminUserName)
        {
            //Admin admins = _adminDal.Get(a => a.UserName == admin.UserName & a.Password == admin.Password);
            //if(admins != null)
            //{
            //    return true;
            //}
            //return false;
            Admin admin = _adminDal.Get(a => a.UserName == adminUserName);
            return admin;     
        }
    }
}
