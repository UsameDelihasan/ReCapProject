using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;


        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }



        public IResult Add(Rental rental)
        {
            var checkIfRentalReturned = _rentalDal.GetAll(r => r.Id == rental.Id && rental.ReturnDate != null);

            if (checkIfRentalReturned != null)
            {
                
                _rentalDal.Add(rental);
                
                return new SuccessResult();
            }

            else
            {
                return new ErrorResult();
            }
        }



        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult();
        }



        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(null));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), Messages.SuccessResult);
        }



        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult(Messages.SuccessResult);
        }
    }
}
