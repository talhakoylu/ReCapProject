using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length < 2)
            {
                return new ErrorResult(Messages.UserAddErrorName);
            }
            
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAddSuccess);
        }

        public IResult Delete(User user)
        {
            var result = _userDal.Get(u => u.Id == user.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.UserDeleteError);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleteSuccess);
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<User>>(Messages.UserGetAllError);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserGetAllSuccess);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userDal.Get(u => u.Id == id);
            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.UserGetByIdError);
            }
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.UserGetByIdSuccess);
        }

        public IResult Update(User user)
        {
            var result = _userDal.Get(u => u.Id == user.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.UserUpdateError);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdateSuccess);
        }
    }
}
