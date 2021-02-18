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
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalGetAllSuccess);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),
                Messages.RentalGetAllSuccess);
        }

        public IResult Add(Rental rental)
        {
            var results = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            foreach (var result in results)
            {
                if (result.ReturnDate == null || result.RentDate > result.ReturnDate)
                {
                    return new ErrorResult(Messages.RentalAddError);
                }
            }

            ValidationTool.Validate(new RentalValidator(), rental);

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAddSuccess);

        }

        public IResult Update(Rental rental)
        {
            var result = _rentalDal.Get(c => c.Id == rental.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.RentalUpdateError);
            }

            ValidationTool.Validate(new RentalValidator(), rental);

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdateSuccess);
        }

        public IResult Delete(Rental rental)
        {
            var result = _rentalDal.Get(c => c.Id == rental.Id);
            if (result == null)
            {
                return new ErrorResult(Messages.RentalDeleteError);
            }

            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleteSuccess);
        }
    }
}
