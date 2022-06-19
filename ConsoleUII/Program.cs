using Business.Abstract;
using Business.Concrete;
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

            Car car1 = new Car() { Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 1, Description = "sadece tekerlek", ModelYear = 902 };
            Car car2 = new Car() { Id = 3, BrandId = 3, ColorId = 3, DailyPrice = 3, Description = "üzerine meteor düşmüş", ModelYear = 22 };
            Car car2Updated = new Car() { Id = 3, BrandId = 3, ColorId = 3, DailyPrice = 3, Description = "şaka yaptım", ModelYear = 22 };

            ICarService carManager = new CarManager(new InMemoryCarDal());


            var getall = carManager.GetAll();
            Console.WriteLine("GetAll :");
            foreach (var item in getall)
            {
                Console.WriteLine(item.Description);
            }

            Console.WriteLine(" ");



            var getbyid = carManager.GetById(1);
            Console.WriteLine("GetById :");
            Console.WriteLine(getbyid.Description);

            Console.WriteLine(" ");



            carManager.Add(car2);
            var getAllAfterAdded = carManager.GetAll();
            Console.WriteLine("GetAll After Added:");
            Printer(getAllAfterAdded);

            Console.WriteLine(" ");


            carManager.Update(car2Updated);
            var getAllAfterUpdated = carManager.GetAll();
            Console.WriteLine("GetAll After Updated :");
            Printer(getAllAfterUpdated);

            Console.WriteLine(" ");

            carManager.Delete(car2);
            var getAllAfterDeleted = carManager.GetAll();

            Console.WriteLine("GetAll After Deleted :");
            Printer(getAllAfterDeleted);




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
