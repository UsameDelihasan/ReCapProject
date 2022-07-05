using Business.Abstract;
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

        public List<Car> GetAll()
        {
            return _carDal.GetAll(null);
        }

        public Car GetById(int id)
        {
            return _carDal.GetById(id);
          
        }


        
        public void Add(Car car)
        {
            if (car.CarName.Length>=2 )
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                }

                else
                {
                    Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
                }
            }
            else
            {

                Console.WriteLine("Araba ismi en az 2 karakterli olmalı veya araba günlük fiyatı 0'dan büyük olmalı");
            }
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public Car GetCarsByBrandId(int id)
        {
            return _carDal.GetByBrandId(id);
        }

        public Car GetCarsByColorsId(int id)
        {
            return _carDal.GetByColorId(id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
