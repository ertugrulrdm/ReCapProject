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

            //Objects for tests

            Car carForTest = new Car
            {
                CarId = 7,
                CarName = "Renault Clio",
                BrandId = 2,
                ColorId = 5,
                DailyPrice = 330,
                ModelYear = 2019,
                Description = "2019 model mavi Renault Clio.",
            };

            Car carForUpdate = new Car
            {
                CarId = 7,
                CarName = "Renault Clio",
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 330,
                ModelYear = 2019,
                Description = "2019 model beyaz Renault Clio.",
            };

            Color colorForTest = new Color
            {
                ColorId = 6,
                ColorName = "Bordo",
            };

            Brand brandForTest = new Brand
            {
                BrandId = 6,
                BrandName = "Audi",
            };


            //Tests
            //------------

            //MainCarTest();
            //MainColorTest();
            //MainBrandTest();
            //AddCar(carForTest);
            //DeleteCar(carForTest);
            //UpdateCar(carForUpdate);
            //GetCarById();
            //GetAllCars();
            //GetCarByColorId();
            //GetCarByBrandId();
        }

        private static void GetCarByColorId(int colorId)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> carList = new List<Car>();
            foreach (var car in carManager.GetByColorId(colorId))
            {
                carList.Add(car);
            }
            Console.WriteLine("Rengi {0} olan arabalar;", colorManager.GetById(colorId).ColorName.ToLower());
            for (int i = 0; i < carList.Count; i++)
            {
                Console.WriteLine(carList[i].CarName);
            }
        }

        private static void GetCarByBrandId(int brandId)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CarManager carManager = new CarManager(new EfCarDal());
            List<Car> carList = new List<Car>();
            Console.WriteLine("Markası {0} olan araba modelleri;", brandManager.GetById(brandId).BrandName);
            foreach (var car in carManager.GetByBrandId(brandId))
            {
                carList.Add(car);
            }
            for (int i = 0; i < carList.Count; i++)
            {
                Console.WriteLine(carList[i].CarName);
            }
        }
        private static void MainColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("---------");
                Console.WriteLine("ID: {0}\nRenk: {1}", color.ColorId, color.ColorName);
                Console.WriteLine("---------\n");
            }
        }

        private static void GetAllCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var cars = carManager.GetAll();
            foreach (var car in cars)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void GetCarById()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var carFromDb = carManager.GetById(3);
            Console.WriteLine("Arabanın adı {0}", carFromDb.CarName);
        }


        //This method must be used with Add method for run properly.
        private static void UpdateCar(Car carForUpdate)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(carForUpdate);
        }

        private static void DeleteCar(Car carForTest)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(carForTest);
        }

        private static void AddCar(Car carForTest)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(carForTest);
        }

        private static void MainCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("---------");
                Console.WriteLine("Arabanın;\n");
                Console.WriteLine("Adı: {0}\nMarkası: {1}\nRengi: {2}\nGünlük Ücreti: {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                Console.WriteLine("---------\n");
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("---------");
                Console.WriteLine("ID: {0}\nMarka: {1}", brand.BrandId, brand.BrandName);
                Console.WriteLine("---------\n");
            }
        }
    }
}

