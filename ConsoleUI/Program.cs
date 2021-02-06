using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            EfCarDal efCarDal = new EfCarDal();
            var cars = carManager.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine("-------------");
                Console.WriteLine("Arabanın;\nID'si: {0}\nMarka ID'si: {1}\nRenk ID'si: {2}\nYılı: {3}\nGünlük Ücreti: {4} TL\nAçıklaması: {5}", car.Id, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Description);
                Console.WriteLine("-------------");
            }
        }
    }
}
