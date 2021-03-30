using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        private IFindeksDal _findeksDal;

        public FindeksManager(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }

        public IDataResult<List<Findeks>> GetAll()
        {
            var result = _findeksDal.GetAll();
            return new SuccessDataResult<List<Findeks>>(result, Messages.FindeksGetAllSuccess);
        }

        public IDataResult<Findeks> GetByUserId(int id)
        {
            var result = _findeksDal.Get(f => f.UserId == id);
            return new SuccessDataResult<Findeks>(result, Messages.FindeksGetByUserIdSuccess);
        }

        public IResult Add(Findeks findeks)
        {
            findeks.FindeksScore = new Random().Next(0, 1901);
            _findeksDal.Add(findeks);
            return new SuccessResult(Messages.FindeksAddSuccess);
        }
    }
}
