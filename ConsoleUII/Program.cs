using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ConsoleUII
{
    class Program
    {
        static void Main(string[] args)
        {

            

            //Car Tesla = new Car() { Id = 1, BrandId = 2, CarName = "Tesla Cybertruck", ColorId = 1, DailyPrice = 200, Description = " Elektrikli araba", ModelYear = 2020 };
            //Car TOGG = new Car() { Id = 2, BrandId = 1, CarName = "TOGG C-SUV", ColorId = 3, DailyPrice = 500, Description = " Milli Elektrikli araba", ModelYear = 2022 };


            


            //Brand brandTesla = new Brand() { Id = 2, Name = "Tesla " };
            //Brand brandMercedes = new Brand() { Id = 4, Name = "Mercedes" };
            //Brand brandBMW = new Brand() { Id = 3, Name = "BMW" };

            //Color blue = new Color() { Id = 1, Name = "Mavi" };
            //Color black = new Color() { Id = 2, Name = "Siyah" };



            
            IBrandService brandManager = new BrandManager(new EfBrandDal());
            IColorService colorManager = new ColorManager(new EfColorDal());
            ICarService carManager = new CarManager(new EfCarDal());
            IRentalService rentalManager = new RentalManager(new EfRentalDal());




            var getAll = carManager.GetAll();
            var getAllColors = colorManager.GetAll();

            //var getCarDetails= carManager.GetCarDetails();


            //foreach (var item in getCarDetails)
            //{
            //    Console.WriteLine($"{item.CarName} / {item.BrandName} / {item.ColorName} / {item.DailyPrice}");
            //}



            //Printer(getAllColors);









        }

        static void Printer(List<Color> print)
        {
            foreach (var item in print)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
