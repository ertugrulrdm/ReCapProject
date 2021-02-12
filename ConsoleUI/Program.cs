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

            Customer customer1 = new Customer
            {
                CompanyName = "Microsoft Corp.",
            };

            Customer customer2 = new Customer
            {
                CompanyName = "Google Inc.",
            };

            Customer customer3 = new Customer
            {
                CompanyName = "Oracle",
            };
            Customer customer4 = new Customer
            {
                CompanyName = "Apple Inc.",
            };

            Customer customer5 = new Customer
            {
                CompanyName = "Intel Corp.",
            };

            User user1 = new User
            {
                FirstName = "Engin",
                LastName = "Demiroğ",
                Email = "engindemirog@gmail.com",
                Password = "123456",
            };

            User user2 = new User
            {
                FirstName = "Kerem",
                LastName = "Varış",
                Email = "keremvaris@gmail.com",
                Password = "123456",
            };

            User user3 = new User
            {
                FirstName = "Murat",
                LastName = "Kurtboğan",
                Email = "muratkurtbogan@gmail.com",
                Password = "123456",
            };

            DateTime rentingDateTime = new DateTime(2021, 2, 11);
            DateTime returningDateTime = new DateTime(2021, 2, 18);

            Rental rentalForTest = new Rental
            {
                RentalId = 1,
                CarId = 5,
                CustomerId = 1,
                RentDate = rentingDateTime,
                ReturnDate = returningDateTime,
            };

            //Tests
            //------------------------
            //AddCar(rentalForTest);
            //DeleteCar(carForTest);
            //UpdateCar(carForUpdate);
            //AddRental(rental);
            //AddCustomer(customer);
            //AddUser(user);
        }

        private static void AddUser(User user)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var addedUser = userManager.Add(user);
            Console.WriteLine(addedUser.Message + "\nEklenen kullanıcı: {0} {1}", user.FirstName, user.LastName);
        }

        private static void AddCustomer(Customer customer)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var addedCustomer = customerManager.Add(customer);
            Console.WriteLine(addedCustomer.Message + "\nEklenen müşteri şirketin adı: {0}", customer.CompanyName);
        }

        private static void AddRental(Rental rental)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var addedRental = rentalManager.Add(rental);
            Console.WriteLine(addedRental.Message);
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
    }
}

