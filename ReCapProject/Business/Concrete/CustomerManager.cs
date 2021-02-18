using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerGetAllSuccess);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == id));
        }

        public IResult Add(Customer customer)
        {
            ValidationTool.Validate(new CustomerValidator(), customer);

            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAddSuccess);
        }

        public IResult Update(Customer customer)
        {
            var result = _customerDal.Get(c => c.UserId == customer.UserId);
            if (result == null)
            {
                return new ErrorResult(Messages.CustomerUpdateError);
            }

            ValidationTool.Validate(new CustomerValidator(), customer);

            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdateSuccess);
        }

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
