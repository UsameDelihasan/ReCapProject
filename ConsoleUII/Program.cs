using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUII
{
    class Program
    {
        static void Main(string[] args)
        {

            Car car1 = new Car() { Id = 2,CarName="Audi", BrandId = 2, ColorId = 2, DailyPrice = 1, Description = "bir kerelik fay hattına düştü", ModelYear = 902 };
            Car car2 = new Car() { Id = 3, CarName="Mini Cooper", BrandId = 1, ColorId = 3, DailyPrice = 3, Description = "üzerine meteor düşmüş", ModelYear = 22 };
            Car car3 = new Car() { Id = 4, CarName="Zn", BrandId = 2, ColorId = 1, DailyPrice = -2, Description = "Binek Hayvan", ModelYear = 22 };
            Car car2Updated = new Car() { Id = 3, BrandId = 3, ColorId = 3, DailyPrice = 3, Description = "şaka yaptım", ModelYear = 22 };

            ICarService carManager = new CarManager(new EfCarDal());


            carManager.Add(car3);
            var result = carManager.GetAll();
            
            foreach (var item in result)
            {
                Console.WriteLine(item.ModelYear);
            }

            Console.WriteLine(carManager.GetCarsByBrandId(1).Description);
            Console.WriteLine(carManager.GetCarsByColorsId(2).Description);











            //var getall = carManager.GetAll();
            //Console.WriteLine("GetAll :");
            //foreach (var item in getall)
            //{
            //    Console.WriteLine(item.Description);
            //}

            //Console.WriteLine(" ");




            //var getbyid = carManager.GetById(1);
            //Console.WriteLine("GetById :");
            //Console.WriteLine(getbyid.Description);

            //Console.WriteLine(" ");



            //carManager.Add(car2);
            //var getAllAfterAdded = carManager.GetAll();
            //Console.WriteLine("GetAll After Added:");
            //Printer(getAllAfterAdded);

            //Console.WriteLine(" ");


            //carManager.Update(car2Updated);
            //var getAllAfterUpdated = carManager.GetAll();
            //Console.WriteLine("GetAll After Updated :");
            //Printer(getAllAfterUpdated);

            //Console.WriteLine(" ");

            //carManager.Delete(car2);
            //var getAllAfterDeleted = carManager.GetAll();

            //Console.WriteLine("GetAll After Deleted :");
            //Printer(getAllAfterDeleted);




        }

        static void Printer(List<Car> print)
        {
            foreach (var item in print)
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}
