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
    public class MessageManager : IMessageService
    {

        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public IResult Add(Message message)
        {
            _messageDal.Add(message);
            return new SuccessResult("mail geldi");
        }

        public IResult Delete(Message message)
        {
           _messageDal.Delete(message);
            return new SuccessResult("mail silindi");
        }

        public IDataResult<List<Message>> GetAll()
        {
            return new SuccessDataResult<List<Message>>(_messageDal.GetAll(), "gelen kutusu listelendi...");
        }
    }
}
