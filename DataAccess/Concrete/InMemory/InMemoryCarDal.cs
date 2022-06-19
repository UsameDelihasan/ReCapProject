﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=305, Description="Mercedes", ModelYear=1999 }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {


            car = _cars.SingleOrDefault(p => p.Id == car.Id);

            _cars.Remove(car);
        }

        public List<Car> GetAll()
        {
            return _cars.ToList();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate=null;

            carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);

            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;

        }
    }
}