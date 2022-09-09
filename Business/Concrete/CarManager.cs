using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;

        

        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(null),Messages.SuccessResult);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.SuccessResult);
        }


        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            

            if(CheckIfCarCountOfBrandCorrect(car.BrandId).Success);
            {
                if (CheckIfCarNameExist(car.CarName).Success)
                {
                    _carDal.Add(car);
                }
               
                return new SuccessResult(Messages.CarAdded);
            }

            

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Messages.SuccessResult);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.SuccessResult);
        }

        public IDataResult<Car> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetByBrandId(id), Messages.SuccessResult);
        }

        public IDataResult<Car> GetCarsByColorsId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.GetByColorId(id), Messages.SuccessResult);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.SuccessResult);
        }





         

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            List<Car> cars = _carDal.GetAll(p => p.BrandId == brandId);

            if (!(cars.Count <= 10))
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarNameExist(string carName)
        {
            var result = _carDal.GetAll(n => n.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceeded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}
