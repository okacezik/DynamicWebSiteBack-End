using Business.Abstracts;
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
    public class MissionManager : IMissionService
    {

        IMissionDal _missionDal;

        public MissionManager(IMissionDal missionDal)
        {
            _missionDal = missionDal;
        }

        public IResult Add(Mission mission)
        {
            _missionDal.Add(mission);
            return new SuccessResult("görev eklendi...");
        }

        public IDataResult<List<Mission>> GetAll()
        {
            return new SuccessDataResult<List<Mission>>(_missionDal.GetAll(), "görevler listelendi...");
        }
    }
}
