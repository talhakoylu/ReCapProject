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
    public class UserCreditCardManager : IUserCreditCardService
    {
        private IUserCreditCardDal _userCreditCardDal;

        public UserCreditCardManager(IUserCreditCardDal userCreditCardDal)
        {
            _userCreditCardDal = userCreditCardDal;
        }

        public IDataResult<List<UserCreditCard>> GetAll()
        {
            var result = _userCreditCardDal.GetAll();
            return new SuccessDataResult<List<UserCreditCard>>(result, Messages.UserCreditCardGetAllSuccess);
        }

        public IDataResult<List<UserCreditCard>> GetAllByUserId(int id)
        {
            var result = _userCreditCardDal.GetAll(u => u.UserId == id);
            return new SuccessDataResult<List<UserCreditCard>>(result, Messages.UserCreditCardGetAllByUserIdSuccess);
        }

        public IDataResult<UserCreditCard> GetById(int id)
        {
            var result = _userCreditCardDal.Get(c => c.Id == id);
            return new SuccessDataResult<UserCreditCard>(result, Messages.UserCreditCardGetByIdSuccess);
        }

        public IResult Add(UserCreditCard userCreditCard)
        {
            _userCreditCardDal.Add(userCreditCard);
            return new SuccessResult(Messages.UserCreditCardAddSuccess);
        }

        public IResult Update(UserCreditCard userCreditCard)
        {
            _userCreditCardDal.Update(userCreditCard);
            return new SuccessResult(Messages.UserCreditCardUpdateSuccess);
        }

        public IResult Delete(UserCreditCard userCreditCard)
        {
            _userCreditCardDal.Delete(userCreditCard);
            return new SuccessResult(Messages.UserCreditCardDeleteSuccess);
        }
    }
}
