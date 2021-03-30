using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspects("IUserService.Get")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAddSuccess);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspects("IUserService.Get")]
        public IResult Delete(User user)
        {
            IResult result = BusinessRules.Run(CheckUserExists(user.Id));
            if (result != null)
            {
                return result;
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleteSuccess);
        }

        [CacheAspect()]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserGetAllSuccess);
        }

        [CacheAspect()]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), Messages.UserGetByIdSuccess);
        }

        
        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email),
                "usermanager getbymail refactor edilecek alan");
        }

        
        public IDataResult<List<OperationClaimDto>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaimDto>>(_userDal.GetClaims(user), "usermanager getclaims refactor edilecek alan");
        }

        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspects("IUserService.Get")]
        public IResult Update(UserProfileUpdateDto userPasswordUpdateDto)
        {
            IResult result = BusinessRules.Run(CheckUserExists(userPasswordUpdateDto.User.Id), PasswordVerifyForUpdate(userPasswordUpdateDto));
            if (result != null)
            {
                return result;
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userPasswordUpdateDto.Password, out passwordHash,out passwordSalt);
            var userBind = new User()
            {
                Id = userPasswordUpdateDto.User.Id,
                FirstName = userPasswordUpdateDto.User.FirstName,
                LastName = userPasswordUpdateDto.User.LastName,
                Email = userPasswordUpdateDto.User.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userDal.Update(userBind);
            return new SuccessResult(Messages.UserUpdateSuccess);
        }

        //business rules
        private IResult CheckUserExists(int id)
        {
            var result = _userDal.Get(u => u.Id == id);
            if (result == null)
            {
                return new ErrorResult(Messages.UserCheckUserExistsError);
            }

            return new SuccessResult();
        }

        private IResult PasswordVerifyForUpdate(UserProfileUpdateDto userPasswordUpdateDto)
        {
            var userResult = _userDal.Get(u => u.Id == userPasswordUpdateDto.User.Id);

            var passwordCheckResult = HashingHelper.VerifyPasswordHash(userPasswordUpdateDto.Password,
                userResult.PasswordHash, userResult.PasswordSalt);
            if (passwordCheckResult == false)
            {
                return new ErrorResult("PasswordVerifyForUpdate UserManager Error Refactor lazım");
            }

            return new SuccessResult();

        }
    }
}
