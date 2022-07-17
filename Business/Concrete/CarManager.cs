using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(null),Messages.SuccessResult);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.SuccessResult);
        }


        
        public IResult Add(Car car)
        {
             

            if (car.CarName.Length>=2 )
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);

                    

                    return new SuccessResult(Messages.SuccessResult);
                }

                else
                {
                    Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
                    return new ErrorResult(Messages.ErrorResult);
                }
            }
            else
            {

                Console.WriteLine("Araba ismi en az 2 karakterli olmalı veya araba günlük fiyatı 0'dan büyük olmalı");
                return new ErrorResult(Messages.ErrorResult);
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
    }
}
