using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [CacheAspect()]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerGetAllSuccess);
        }

        [CacheAspect()]
        public IDataResult<List<CustomerDetailDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetailsDto(),
                Messages.CustomerGetAllSuccess);
        }

        [CacheAspect()]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == id));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspects("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAddSuccess);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspects("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            var result = _customerDal.Get(c => c.UserId == customer.UserId);
            if (result == null)
            {
                return new ErrorResult(Messages.CustomerUpdateError);
            }

            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdateSuccess);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspects("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            var result = _customerDal.Get(c => c.UserId == customer.UserId);
            if (result == null)
            {
                return new ErrorResult(Messages.CustomerDeleteError);
            }

            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleteSuccess);
        }
    }
}
